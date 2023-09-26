using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console.PropertyFinders;

internal abstract class SimpleOneHitPropertyFinder : BaseOneHitPropertyFinder
{
    protected virtual int PreWait { get; set; } = 5;
    protected abstract string Url { get; set; }
    protected abstract string CSSSelector { get; set; }

    protected SimpleOneHitPropertyFinder(ExceptionStore exceptionStore) 
        : base(exceptionStore)
    {
    }

    protected override Task<IEnumerable<Property>> DoFind()
    {
        var page = WebBrowser.Launch().GoTo(Url);
        Thread.Sleep(PreWait * 1000);
        var properties = page.GetLinks(CSSSelector)
            .Select(x => Property.Create(EstateAgents.Other, x));
        page.CloseBrowser();

        return Task.FromResult(properties);
    }
}