using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class FoxtonsPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        var page = WebBrowser.Launch().GoToFoxtons(postCode)
            .AcceptCookies();
        var properties = page.GetLinks()
            .Select(x => Property.Create(EstateAgents.Foxtons, x));
        page.CloseBrowser();
        
        return Task.FromResult(properties);
    }
}