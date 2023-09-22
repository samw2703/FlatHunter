namespace FlatHunter.Crawler.Core.OnTheMarket;

public interface IOnTheMarketResultsPage : IWebPage
{
    int GetPageCount();
    IOnTheMarketResultsPage GoToPage(int page);
    IEnumerable<string> GetLinks();
}