using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class ZooplaPropertyFinder : BasePropertyFinder
{
    public ZooplaPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }

    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoToZoopla()
            .AcceptCookies().ClickToRent().EnterSearch(postCode).ClickSearch();

        page.CloseBrowser();
        throw new NotImplementedException();
    }
}