using FlatHunter.Crawler.Core;

namespace FlatHunter.Console.PropertyFinders;

internal class JTMHomesPropertyFinder : SimplePropertyFinder
{
    public JTMHomesPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }

    protected override string CSSSelector { get; set; } = "section > .relative.span12 .prod-thumb-image.span6 > a";

    protected override string GetUrl(string postCode)
        => $"https://www.jtmhomes.co.uk/products.php?search={postCode}&searchRoomsLow=3&searchRoomsHigh=3&cat=2&searchPriceLow=400&searchPriceHigh=700&forrent=";

    protected override void PostLoadProcessing(IHomePage page)
    {
        page.Click("div#facet-ajax-update > .row-fluid.sort-pagination-bar .sort-pagination-prods-container > a:nth-of-type(1)");
        Thread.Sleep(5 * 1000);
    }
}