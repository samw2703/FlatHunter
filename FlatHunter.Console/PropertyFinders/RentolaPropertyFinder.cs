using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class RentolaPropertyFinder : BasePropertyFinder
{
    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoToRentola()
            .AcceptCookies().EnterSearch(postCode).ClickTopOption()
            .AppendToUrl(3000, 3, 3).LoadAllResults();
        var properties = page.GetLinks().Select(x => Property.Create(EstateAgents.Rentola, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }

    public RentolaPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }
}