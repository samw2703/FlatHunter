using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class RentolaPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        var page = WebBrowser.Launch().GoToRentola()
            .AcceptCookies().EnterSearch(postCode).ClickTopOption()
            .AppendToUrl(3000, 3, 3).LoadAllResults();
        var properties = page.GetLinks().Select(x => Property.Create(EstateAgents.Rentola, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }
}