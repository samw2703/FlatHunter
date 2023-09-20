using FlatHunter.Crawler.Core.OpenRent;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.OpenRent;

internal class OpenRentResultsPage : SeleniumWebPage, IOpenRentResultsPage
{
    public OpenRentResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(2))
    {
    }

    public IOpenRentResultsPage AppendToUrl(int distance, int minPrice, int maxPrice, int minBedroom, int maxBedroom)
    {
        var url = $"{GetUrl()}&area={distance}&prices_min={minPrice}&prices_max={maxPrice}&bedrooms_min={minBedroom}&bedrooms_max={maxBedroom}";
        return GoTo(url, x => new OpenRentResultsPage(x));
    }

    public IOpenRentResultsPage SetDistance(int value)
    {
        EnterText(By.Id("commuteTime"), value.ToString());
        return this;
    }

    public IOpenRentResultsPage ClickPriceFilter()
    {
        Click(By.CssSelector(".filter-search-cont .price-btn"));
        Thread.Sleep(500);
        return this;
    }

    public IOpenRentResultsPage SetMinPrice(int value)
    {
        DropdownByValue(By.CssSelector(".filter-search-cont .form-control.price-select.prices_min_select.pim"), value.ToString());
        Thread.Sleep(500);
        return this;
    }

    public IOpenRentResultsPage SetMaxPrice(int value)
    {
        DropdownByValue(By.CssSelector(".filter-search-cont .form-control.price-select.prices_max_select.pim"), value.ToString());
        Thread.Sleep(500);
        return this;
    }

    public IOpenRentResultsPage ClickBedFilter()
    {
        Click(By.CssSelector(".filter-search-cont .dropdown-toggle:has(> .beds-copy)"));
        Thread.Sleep(2000);
        return this;
    }

    public IOpenRentResultsPage SetMinBed(int value)
    {
        DropdownByValue(By.CssSelector(".filter-search-cont > .initial-filter-cont .dropdown-beds.dropdown-menu.form-inline  .input-group > div:nth-of-type(1) > select"), value.ToString());
        Thread.Sleep(2000);
        return this;
    }

    public IOpenRentResultsPage SetMaxBed(int value)
    {
        DropdownByValue(By.CssSelector(".filter-search-cont > .initial-filter-cont .dropdown-beds.dropdown-menu.form-inline  .input-group > div:nth-of-type(2) > select"), value.ToString());
        Thread.Sleep(2000);
        return this;
    }

    public IOpenRentResultsPage ClickBedUpdate()
    {
        Click(By.CssSelector(".dropdown-menu.dropdown-prices.form-inline  .btn.btn-advanced-search.btn-primary.btn-small.updatePricingOptions"));
        Thread.Sleep(2000);
        return this;
    }

    public IOpenRentResultsPage ClickSearch()
    {
        Click(By.Id("searchButton"));
        return HandleNavigate(x => new OpenRentResultsPage(x));
    }

    public IOpenRentResultsPage ScrollRightToBottom()
    {
        ScrollDownFor(10);
        return this;
    }

    public IEnumerable<string> GetLinks()
    {
        return GetHrefs(By.CssSelector("#property-data .pli")).ToList();
    }
}