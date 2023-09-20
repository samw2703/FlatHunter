using FlatHunter.Crawler.Core.Spareroom;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Spareroom;

internal class SpareroomLandingPage : SeleniumWebPage, ISpareroomLandingPage
{
    public SpareroomLandingPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(2))
    {
    }

    public ISpareroomLandingPage AcceptCookies()
    {
        Click(By.Id("onetrust-accept-btn-handler"));
        return this;
    }

    public ISpareroomLandingPage EnterSearch(string searchText)
    {
        EnterText(By.Id("search_by_location_field"), searchText);
        return this;
    }

    public ISpareroomResultsPage ClickSearch()
    {
        return ClickNavigate(By.Id("search_by_location_submit_button"), x => new SpareroomResultsPage(x));
    }
}