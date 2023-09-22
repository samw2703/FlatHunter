using FlatHunter.Crawler.Core.Foxtons;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Foxtons;

internal class FoxtonsResultsPage : SeleniumWebPage, IFoxtonsResultsPage
{
    public FoxtonsResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }

    public IFoxtonsResultsPage AcceptCookies()
    {
        Click(By.CssSelector(".accept_all .cookie_option"));
        return this;
    }

    public IEnumerable<string> GetLinks()
        => GetHrefs(By.CssSelector(".content_holder > .property_holder .property_photo_holder")).Distinct();
}