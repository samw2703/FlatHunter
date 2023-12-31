using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class SpareroomPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoToSpareroom()
            .AcceptCookies().EnterSearch(postCode).ClickSearch()
            .SetMinPrice(2000).SetMaxPrice(3000)
            .RemoveExistingShares().RemoveStudios()
            .ClickApplyFilters();
        var properties = page.GetLinks()
            .Select(x => Property.Create(EstateAgents.Spareroom, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }

    public SpareroomPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}