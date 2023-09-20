using FlatHunter.Crawler.Core.Kinleigh;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Kinleigh;

internal class KinleighResultsPage : SeleniumWebPage, IKinleighResultsPage
{
    public KinleighResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }

    public IEnumerable<string> GetLinks()
    {
        return GetHrefs(By.CssSelector(".PropertyCard__StyledPropertyCard-sc-1kiuolp-0 .PropertyCard__StyledBody-sc-1kiuolp-1 .PropertyCard__StyledActions-sc-1kiuolp-6 a"));
    }
}