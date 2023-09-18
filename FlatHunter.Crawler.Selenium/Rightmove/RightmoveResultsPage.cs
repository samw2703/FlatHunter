using FlatHunter.Crawler.Core.Rightmove;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Rightmove;

internal class RightmoveResultsPage : SeleniumWebPage, IRightmoveResultsPage
{
    public RightmoveResultsPage(IWebDriver webDriver) 
        : base(webDriver, LoadWaitArgs.UntilExists(By.CssSelector(".ksc_button.large.tertiary.addNewKeywordButton")))
    {
    }

    public int GetPageCount()
    {
        return Convert.ToInt32(GetText(By.CssSelector(".pagination-pageSelect > :nth-child(4)")));
    }

    public IRightmoveResultsPage GoToPage(int page)
    {
        DropdownByText(By.CssSelector(".select.pagination-dropdown"), page.ToString());
        return HandleNavigate(x => new RightmoveResultsPage(x));
    }

    public (IRightmoveResultsPage Page, IEnumerable<string> AdvertLinks) GetAdvertLinks()
    {
        var links = GetHrefs(By.CssSelector(".propertyCard-link.property-card-updates"));

        return (this, links);
    }
}