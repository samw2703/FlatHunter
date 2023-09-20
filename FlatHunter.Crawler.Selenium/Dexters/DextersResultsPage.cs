using FlatHunter.Crawler.Core.Dexters;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Dexters;

internal class DextersResultsPage : SeleniumWebPage, IDextersResultsPage
{
    public DextersResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }

    public IDextersResultsPage GoToUrl(int minPrice, int maxPrice, int bedrooms, string postcode)
    {
        var url = $"https://www.dexters.co.uk/property-lettings/{bedrooms}-bedroom-properties-to-rent-in-{postcode}-between-{minPrice}-and-{maxPrice}";
        return GoTo(url, x => new DextersResultsPage(x));
    }

    public IEnumerable<string> GetLinks()
    {
        return GetHrefs(By.CssSelector(".result-image a"));
    }
}