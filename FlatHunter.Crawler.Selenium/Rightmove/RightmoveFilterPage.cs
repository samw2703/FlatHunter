using FlatHunter.Crawler.Core.Rightmove;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Rightmove;

internal class RightmoveFilterPage: SeleniumWebPage, IRightmoveFilterPage
{
    public RightmoveFilterPage(IWebDriver webDriver) 
        : base(webDriver, LoadWaitArgs.UntilExists(By.CssSelector("")))
    {
    }

    public IRightmoveFilterPage SetMinBedrooms(int value)
    {
        throw new NotImplementedException();
    }

    public IRightmoveFilterPage SetMaxBedrooms(int value)
    {
        throw new NotImplementedException();
    }

    public IRightmoveFilterPage SetMaxPrice(int value)
    {
        throw new NotImplementedException();
    }

    public IRightmoveResultsPage ClickFindProperties()
    {
        throw new NotImplementedException();
    }
}