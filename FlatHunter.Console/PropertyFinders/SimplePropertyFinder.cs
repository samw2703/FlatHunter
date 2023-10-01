using FlatHunter.Core;
using FlatHunter.Crawler.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal abstract class SimplePropertyFinder : BasePropertyFinder
{
    protected virtual int PreWait { get; set; } = 5;
    protected abstract string CSSSelector { get; set; }

    protected SimplePropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }

    protected override Task<IEnumerable<Property>> DoFind(string postCode)
    {
        var page = WebBrowser.Launch().GoTo(GetUrl(postCode));
        Thread.Sleep(PreWait * 1000);
        PostLoadProcessing(page);
        var properties = page.GetLinks(CSSSelector)
            .Select(x => Property.Create(EstateAgents.Other, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }

    protected abstract string GetUrl(string postCode);

    protected virtual void PostLoadProcessing(IHomePage page)
    {
    }
}