namespace FlatHunter.Crawler.Core.Spareroom;

public interface ISpareroomLandingPage : IWebPage
{
    ISpareroomLandingPage AcceptCookies();
    ISpareroomLandingPage EnterSearch(string searchText);
    ISpareroomResultsPage ClickSearch();
}