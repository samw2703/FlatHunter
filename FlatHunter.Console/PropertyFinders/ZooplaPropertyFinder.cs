using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal class ZooplaPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        var page = WebBrowser.Launch().GoToZoopla()
            .AcceptCookies().ClickToRent().EnterSearch(postCode).ClickSearch();

        page.CloseBrowser();
        throw new NotImplementedException();
    }
}