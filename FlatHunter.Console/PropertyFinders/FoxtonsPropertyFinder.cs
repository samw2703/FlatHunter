using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class FoxtonsPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoToFoxtons(postCode)
            .AcceptCookies();
        var properties = page.GetLinks()
            .Select(x => Property.Create(EstateAgents.Foxtons, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }

    public FoxtonsPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}