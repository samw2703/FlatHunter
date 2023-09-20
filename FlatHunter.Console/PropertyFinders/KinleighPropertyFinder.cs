using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class KinleighPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        var page = WebBrowser.Launch().GoToKinleigh(postCode, 2000, 3000, 3);
        var properties = page.GetLinks().Select(x => Property.Create(EstateAgents.Kinleigh, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }
}