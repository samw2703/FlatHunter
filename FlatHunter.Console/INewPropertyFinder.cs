using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console;

internal interface IPropertyFinder
{
    Task<IEnumerable<Property>> Find(string postCode);
}

internal class NoPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        return Task.FromResult(new List<Property>().AsEnumerable());
    }
}

internal class RightmovePropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        var resultsPage = WebBrowser.Launch().GoToRightmove()
            .RejectCookies().EnterSearch(postCode).ClickToRent()
            .SetMinBedrooms(3).SetMaxBedrooms(3)
            .SetMinPrice(2000).SetMaxPrice(3000)
            .ClickFindProperties();
        var results = resultsPage.GetAdvertLinks()
            .Select(x => Property.Create(EstateAgents.Rightmove, x));
        resultsPage.Close();
        return Task.FromResult(results);
    }
}