using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class DextersPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch()
            .GoToDexters().ClickRent().EnterSearch(postCode).ClickSearch()
            .GoToUrl(2000, 3000, 3, postCode);
        var properties = page.GetLinks()
            .Select(x => Property.Create(EstateAgents.Dexters, x));
        page.CloseBrowser();
        return Task.FromResult(properties);
    }

    public DextersPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}