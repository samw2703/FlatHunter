using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium;

internal abstract class SeleniumWebPage
{
    private readonly IWebDriver _webDriver;
    private readonly LoadWait _loadWait;

    protected virtual int MaxLoadWaitSeconds { private get; set; } = 5;


    protected SeleniumWebPage(IWebDriver webDriver, LoadWaitArgs args)
    {
        _webDriver = webDriver;
        _loadWait = new LoadWait(args.Exists, args.DoesNotExist, _webDriver);
    }

    protected T GoTo<T>(string url, Func<IWebDriver, T> createPage) where T : SeleniumWebPage
    {
        _webDriver.Navigate().GoToUrl(url);
        var page = createPage(_webDriver);
        page.WaitForLoad();
        return page;
    }

    protected void EnterText(By by, string text)
    {
        var element = _webDriver.FindElement(by);

        element.Clear();
        element.SendKeys(text);
    }

    protected void Click(By by)
    {
        _webDriver.FindElement(by).Click();
    }

    protected T ClickNavigate<T>(By by, Func<IWebDriver, T> createPage) where T : SeleniumWebPage
    {
        _webDriver.FindElement(by).Click();
        var page = createPage(_webDriver);
        page.WaitForLoad();
        return page;
    }

    private void WaitForLoad()
    {
        var cutoff = DateTime.Now.AddSeconds(MaxLoadWaitSeconds);
        while (DateTime.Now < cutoff)
        {
            if (_loadWait.CanContinue())
                return;

            Thread.Sleep(250);
        }

        throw new Exception("LoadWaitExpired");
    }

    private class LoadWait
    {
        private readonly By? _exists;
        private readonly By? _doesNotExist;
        private readonly IWebDriver _webDriver;

        public LoadWait(By? exists, By? doesNotExist, IWebDriver webDriver)
        {
            _exists = exists;
            _doesNotExist = doesNotExist;
            _webDriver = webDriver;
        }

        public bool CanContinue()
        {
            if (_exists != null)
            {
                var element = _webDriver.TryFindElement(_exists);
                if (element == null)
                    return false;

                return element.Displayed;
            }

            if (_doesNotExist != null)
                return _webDriver.TryFindElement(_doesNotExist) == null;
            
            throw new Exception("LoadWait not configured properly");
        }
    }

    protected class LoadWaitArgs
    {
        public By? Exists { get; }
        public By? DoesNotExist { get; }

        private LoadWaitArgs(By? exists, By? doesNotExist)
        {
            Exists = exists;
            DoesNotExist = doesNotExist;
        }

        public static LoadWaitArgs UntilExists(By by) => new(by, null);
        public static LoadWaitArgs UntilDoesNotExist(By by) => new(by, null);
    }
}