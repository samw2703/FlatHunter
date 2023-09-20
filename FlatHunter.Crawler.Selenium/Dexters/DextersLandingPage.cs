using FlatHunter.Crawler.Core.Dexters;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Dexters;

internal class DextersLandingPage : SeleniumWebPage, IDextersLandingPage
{
    public DextersLandingPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(2))
    {
    }

    public IDextersLandingPage ClickRent()
    {
        Click(By.Id("js-btn-rent"));
        Thread.Sleep(500);
        return this;
    }

    public IDextersLandingPage EnterSearch(string searchText)
    {
        EnterText(By.Id("location_lettings"), searchText);
        return this;
    }

    public IDextersResultsPage ClickSearch()
    {
        return ClickNavigate(By.CssSelector(".search-intro .search-btn"), x => new DextersResultsPage(x));
    }
}