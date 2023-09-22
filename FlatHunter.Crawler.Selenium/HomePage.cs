using FlatHunter.Crawler.Core;
using FlatHunter.Crawler.Core.Chestertons;
using FlatHunter.Crawler.Core.Dexters;
using FlatHunter.Crawler.Core.Kinleigh;
using FlatHunter.Crawler.Core.OnTheMarket;
using FlatHunter.Crawler.Core.OpenRent;
using FlatHunter.Crawler.Core.Rentola;
using FlatHunter.Crawler.Core.Rightmove;
using FlatHunter.Crawler.Core.Spareroom;
using FlatHunter.Crawler.Selenium.Chestertons;
using FlatHunter.Crawler.Selenium.Dexters;
using FlatHunter.Crawler.Selenium.Kinleigh;
using FlatHunter.Crawler.Selenium.OnTheMarket;
using FlatHunter.Crawler.Selenium.OpenRent;
using FlatHunter.Crawler.Selenium.Rentola;
using FlatHunter.Crawler.Selenium.Rightmove;
using FlatHunter.Crawler.Selenium.Spareroom;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;

namespace FlatHunter.Crawler.Selenium;

internal class HomePage : SeleniumWebPage, IHomePage
{
    public HomePage(IWebDriver webDriver) 
        : base(webDriver, LoadWaitArgs.UntilExists(By.CssSelector("")))
    {
    }

    public IRightmoveLandingPage GoToRightmove()
        => GoTo("https://www.rightmove.co.uk/", x => new RightmoveLandingPage(x));

    public IOpenRentLandingPage GoToOpenRent()
        => GoTo("https://www.openrent.co.uk/", x => new OpenRentLandingPage(x));

    public ISpareroomLandingPage GoToSpareroom()
        => GoTo("https://www.spareroom.co.uk/", x => new SpareroomLandingPage(x));

    public IDextersLandingPage GoToDexters()
        => GoTo("https://www.dexters.co.uk/", x => new DextersLandingPage(x));

    public IKinleighResultsPage GoToKinleigh(string postCode, int minPrice, int maxPrice, int bedrooms)
    {
        var url = $"https://www.kfh.co.uk/search-results/?bedrooms={bedrooms}&category=RENTAL&currencyid=1&first=12&kfh=true&longlet=true&multiSearch=postal%3D{postCode}&nearme=false&newhomes=true&onlynewhomes=false&page=1&priceHighest={maxPrice}&priceLowest={minPrice}&riverside=false&shortlet=true&sort=HIGHEST&type=RESIDENTIAL&unavailable=false&underoffer=true";
        return GoTo(url, x => new KinleighResultsPage(x));
    }

    public IChestertonsLandingPage GoToChestertons()
    {
        return GoTo("https://www.chestertons.co.uk", x => new ChestertonsLandingPage(x));
    }

    public IRentolaLandingPage GoToRentola()
        => GoTo("https://rentola.co.uk/", x => new RentolaLandingPage(x));

    public IOnTheMarketResultsPage GoToOnTheMarket(string postCode, int minPrice, int maxPrice, int bedrooms)
    {
        var url = $"https://www.onthemarket.com/to-rent/{bedrooms}-bed-property/{postCode}/?max-price={maxPrice}&min-price={minPrice}&view=grid";
        return GoTo(url, x => new OnTheMarketResultsPage(x));
    }
}