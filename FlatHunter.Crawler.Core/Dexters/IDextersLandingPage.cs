namespace FlatHunter.Crawler.Core.Dexters;

public interface IDextersLandingPage : IWebPage
{
    IDextersLandingPage ClickRent();
    IDextersLandingPage EnterSearch(string searchText);
    IDextersResultsPage ClickSearch();
}