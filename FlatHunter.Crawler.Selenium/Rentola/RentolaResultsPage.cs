using FlatHunter.Crawler.Core.Rentola;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Rentola;

internal class RentolaResultsPage : SeleniumWebPage, IRentolaResultsPage
{
    public RentolaResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(8))
    {
    }

    public IRentolaResultsPage AppendToUrl(int maxPrice, int minRooms, int maxRooms)
    {
        var url = $"{GetUrl()}&rent=0-{maxPrice}&rooms={minRooms}-{maxRooms}";
        return GoTo(url, x => new RentolaResultsPage(x));
    }

    public IRentolaResultsPage LoadAllResults()
    {
        var by = By.Id("load-more");
        while (IsVisible(by))
        {
            Click(by);
            Thread.Sleep(5000);
        }

        return this;
    }

    public IEnumerable<string> GetLinks()
    {
        return GetHrefs(By.CssSelector(".property a:nth-of-type(1)"));
    }
}