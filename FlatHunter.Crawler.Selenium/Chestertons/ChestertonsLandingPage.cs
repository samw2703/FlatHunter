using FlatHunter.Crawler.Core.Chestertons;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Chestertons;

internal class ChestertonsLandingPage : SeleniumWebPage, IChestertonsLandingPage
{
    public ChestertonsLandingPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(3))
    {
    }

    public IChestertonsLandingPage AcceptCookies()
    {
        Click(By.CssSelector(".modal-accept .btn-purple"));
        return this;
    }

    public IChestertonsResultsPage GoToResults(string postCode, int minPrice, int maxPrice, int minBedrooms, int maxBedrooms)
    {
        var url = $"https://www.chestertons.co.uk/en-gb/property-to-rent/gb/postcode/n19/?brh={maxBedrooms}&brl={minBedrooms}&prh={maxPrice}&prl={minPrice}";
        return GoTo(url, x => new ChestertonsResultsPage(x));
    }
}