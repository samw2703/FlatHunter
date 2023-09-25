using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class OnTheMarketPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoToOnTheMarket(postCode, 2000, 3000, 3);
        var pageCount = page.GetPageCount();
        var links = page.GetLinks().ToList();

        for (var i = 2; i <= pageCount; i++)
        {
            page = page.GoToPage(i);
            links.AddRange(page.GetLinks());
        }

        var properties = links.Select(x => Property.Create(EstateAgents.OnTheMarket, x));

        page.CloseBrowser();

        return Task.FromResult(properties);
    }

    public OnTheMarketPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}