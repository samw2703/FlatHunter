using FlatHunter.Crawler.Core.Zoopla;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Zoopla;

internal class ZooplaResultsPage : SeleniumWebPage, IZooplaResultsPage
{
    public ZooplaResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }
}