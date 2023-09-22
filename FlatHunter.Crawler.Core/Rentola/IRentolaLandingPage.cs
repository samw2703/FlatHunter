namespace FlatHunter.Crawler.Core.Rentola;

public interface IRentolaLandingPage : IWebPage
{
    IRentolaLandingPage AcceptCookies();
    IRentolaLandingPage EnterSearch(string searchText);
    IRentolaResultsPage ClickTopOption();
}