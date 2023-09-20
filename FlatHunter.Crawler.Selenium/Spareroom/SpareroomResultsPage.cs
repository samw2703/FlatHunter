using FlatHunter.Crawler.Core.Spareroom;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Spareroom;

internal class SpareroomResultsPage : SeleniumWebPage, ISpareroomResultsPage
{
    public SpareroomResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy())
    {
    }

    public ISpareroomResultsPage SetMinPrice(int value)
    {
        EnterText(By.Id("minRent"), value.ToString());
        return this;
    }

    public ISpareroomResultsPage SetMaxPrice(int value)
    {
        EnterText(By.Id("maxRent"), value.ToString());
        return this;
    }

    public ISpareroomResultsPage RemoveExistingShares()
    {
        var by = By.CssSelector("[for='roomsInShares']");
        ScrollTo(by);
        Click(by);
        return this;
    }

    public ISpareroomResultsPage RemoveStudios()
    {
        var by = By.CssSelector("[for='oneBedOrStudio']");
        ScrollTo(by);
        Click(by);
        return this;
    }

    public ISpareroomResultsPage ClickApplyFilters()
    {
        return ClickNavigate(By.CssSelector(".search-filter__submit [type]"), x => new SpareroomResultsPage(x));
    }

    public IEnumerable<string> GetLinks()
    {
        return GetHrefs(By.CssSelector(".listing-card__link"));
    }
}