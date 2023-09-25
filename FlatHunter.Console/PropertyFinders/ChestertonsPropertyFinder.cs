using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class ChestertonsPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoToChestertons()
            .AcceptCookies().GoToResults(postCode, 2000, 3000, 3, 3);
        var properties = page.GetLinks().Select(x => Property.Create(EstateAgents.Chestertons, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }

    public ChestertonsPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}