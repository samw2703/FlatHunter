using FlatHunter.Crawler.Core.Zoopla;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Zoopla;

internal class ZooplaLandingPage : SeleniumWebPage, IZooplaLandingPage
{
    public ZooplaLandingPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }

    public IZooplaLandingPage AcceptCookies()
    {
        using (SwitchToIFrame(By.Id("gdpr-consent-notice")))
        {
            Thread.Sleep(1000);
            Click(By.CssSelector("#save"));
            return this;
        }
    }

    public IZooplaLandingPage ClickToRent()
    {
        Thread.Sleep(1000);
        Click(By.CssSelector("div:nth-of-type(2) > button[role='tab']"));
        return this;
    }

    public IZooplaLandingPage EnterSearch(string text)
    {
        Thread.Sleep(1000);
        EnterText(By.Id("autosuggest-input"), text);
        return this;
    }

    public IZooplaResultsPage ClickSearch()
    {
        Thread.Sleep(1000);
        return ClickNavigate(By.CssSelector("._1dgm2fc8._1erwn750._1erwn751._1erwn752._1erwn75a"), x => new ZooplaResultsPage(x));
    }
}