using FlatHunter.Crawler.Core.Chestertons;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Chestertons;

internal class ChestertonsResultsPage : SeleniumWebPage, IChestertonsResultsPage
{
    public ChestertonsResultsPage(IWebDriver webDriver) : base(webDriver, LoadWaitArgs.Lazy(3))
    {
    }

    public int GetPageCount()
    {
        var by = By.CssSelector(".extra-padding--bottom [alt='go to the last page']");
        
        return Exists(by)
            ? Convert.ToInt32(GetText(By.CssSelector(".extra-padding--bottom [alt='go to the last page']")))
            : 1;
    }

    public IChestertonsResultsPage GoToPage(int page)
    {
        return ClickNavigate(By.CssSelector($".extra-padding--bottom [alt='skip to page {page}']"), x => new ChestertonsResultsPage(x));
    }

    public IEnumerable<string> GetLinks()
    {
        return GetHrefs(By.CssSelector(".parent-col-8.parent-col-lg-9.parent-col-md-8.parent-col-sm-12 .property-card-header a"));
    }
}