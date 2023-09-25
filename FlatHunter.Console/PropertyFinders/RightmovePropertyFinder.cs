using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class RightmovePropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var resultsPage = WebBrowser.Launch().GoToRightmove()
            .RejectCookies().EnterSearch(postCode).ClickToRent()
            .SetMinBedrooms(3).SetMaxBedrooms(3)
            .SetMinPrice(2000).SetMaxPrice(3000)
            .ClickFindProperties();
        var results = resultsPage.GetAdvertLinks()
            .Select(x => Property.Create(EstateAgents.Rightmove, x));
        resultsPage.CloseBrowser();
        return Task.FromResult(results);
    }

    public RightmovePropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}