using FlatHunter.Crawler.Core.OpenRent;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.OpenRent;

internal class OpenRentLandingPage : SeleniumWebPage, IOpenRentLandingPage
{
    public OpenRentLandingPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(2))
    {
    }

    public IOpenRentLandingPage EnterSearch(string text)
    {
        EnterText(By.Id("searchBox"), text);
        Thread.Sleep(200);
        return this;
    }

    public IOpenRentResultsPage ClickSearch()
    {
        return ClickNavigate(By.Id("embeddedSearchBtn"), x => new OpenRentResultsPage(x));
    }
}