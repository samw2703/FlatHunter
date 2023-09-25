using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;
using OpenQA.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class OpenRentPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch()
            .GoToOpenRent().EnterSearch(postCode).ClickSearch()
            .AppendToUrl(1, 2000, 3000, 3, 3)
            .ScrollRightToBottom();
        var properties = page.GetLinks()
            .ToList()
            .Select(x => Property.Create(EstateAgents.Rightmove, x));
        page.CloseBrowser();
        return Task.FromResult(properties);
    }

    public OpenRentPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}