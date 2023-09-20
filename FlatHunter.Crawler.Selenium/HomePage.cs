using FlatHunter.Crawler.Core;
using FlatHunter.Crawler.Core.Dexters;
using FlatHunter.Crawler.Core.OpenRent;
using FlatHunter.Crawler.Core.Rightmove;
using FlatHunter.Crawler.Core.Spareroom;
using FlatHunter.Crawler.Selenium.Dexters;
using FlatHunter.Crawler.Selenium.OpenRent;
using FlatHunter.Crawler.Selenium.Rightmove;
using FlatHunter.Crawler.Selenium.Spareroom;
using OpenQA.Selenium;

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
}