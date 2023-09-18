using FlatHunter.Crawler.Core.Rightmove;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Rightmove;

internal class RightmoveFilterPage: SeleniumWebPage, IRightmoveFilterPage
{
    public RightmoveFilterPage(IWebDriver webDriver) 
        : base(webDriver, LoadWaitArgs.UntilExists(By.Id("submit")))
    {
    }

    public IRightmoveFilterPage SetMinBedrooms(int value)
    {
        DropdownByValue(By.Id("minBedrooms"), value.ToString());
        return this;
    }

    public IRightmoveFilterPage SetMaxBedrooms(int value)
    {
        DropdownByValue(By.Id("maxBedrooms"), value.ToString());
        return this;
    }

    public IRightmoveFilterPage SetMinPrice(int value)
    {
        DropdownByValue(By.Id("minPrice"), value.ToString());
        return this;
    }

    public IRightmoveFilterPage SetMaxPrice(int value)
    {
        DropdownByValue(By.Id("maxPrice"), value.ToString());
        return this;
    }

    public IRightmoveResultsPage ClickFindProperties()
    {
        return ClickNavigate(By.Id("submit"), x => new RightmoveResultsPage(x));
    }
}