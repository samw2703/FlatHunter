using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console;

internal interface IPropertyFinder
{
    Task<IEnumerable<Property>> Find();
}

internal class NoPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find()
    {
        return Task.FromResult(new List<Property>().AsEnumerable());
    }
}

internal class RightmovePropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find()
    {
        var results = WebBrowser.Launch().GoToRightmove()
            .RejectCookies().EnterSearch("n19").ClickToRent()
            .SetMinBedrooms(3).SetMaxBedrooms(3)
            .SetMinPrice(2000).SetMaxPrice(3000)
            .ClickFindProperties()
            .GetAdvertLinks()
            .Select(x => $"https://www.rightmove.co.uk/{x}")
            .ToList();
        return Task.FromResult(new List<Property>().AsEnumerable());
    }
}