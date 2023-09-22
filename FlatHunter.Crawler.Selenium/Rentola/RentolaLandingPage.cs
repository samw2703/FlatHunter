using FlatHunter.Crawler.Core.Rentola;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Rentola;

internal class RentolaLandingPage : SeleniumWebPage, IRentolaLandingPage
{
    public RentolaLandingPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(8))
    {
    }

    public IRentolaLandingPage AcceptCookies()
    {
        Click(By.CssSelector("#coiPage-1 .coi-banner__accept"));
        return this;
    }

    public IRentolaLandingPage EnterSearch(string searchText)
    {
        EnterText(By.CssSelector(".bg-transparent.flex-1.h-full.outline-none.placeholder\\:text-sm.text-base"), searchText);
        return this;
    }

    public IRentolaResultsPage ClickTopOption()
    {
        Thread.Sleep(2000);
        var href = GetHref(By.CssSelector("li:nth-of-type(1) > .block.font-medium.px-2.py-1.text-base.text-grey-3"));
        return GoTo(href, x => new RentolaResultsPage(x));
    }
}