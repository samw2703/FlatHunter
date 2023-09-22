using FlatHunter.Crawler.Core.OnTheMarket;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.OnTheMarket;

internal class OnTheMarketResultsPage : SeleniumWebPage, IOnTheMarketResultsPage
{
    public OnTheMarketResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }

    public int GetPageCount()
    {
        var selector = By.CssSelector(".flex.items-baseline.justify-center.mb-4.md\\:mb-0.md\\:order-2.md\\:w-auto.order-first.w-full li:last-of-type a");

        return Exists(selector) ? GetTextAsInt(selector) : 1;
    }

    public IOnTheMarketResultsPage GoToPage(int page)
        => ClickNavigate(By.CssSelector($"a[title='Page {page}']"), x => new OnTheMarketResultsPage(x));

    public IEnumerable<string> GetLinks() => GetHrefs(By.CssSelector(".grid-list-tabcontent:nth-of-type(1) .otm-PropertyCard .otm-PropertyCardMedia [rel]"));
}