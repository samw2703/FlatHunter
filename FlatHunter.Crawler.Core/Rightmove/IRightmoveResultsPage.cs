namespace FlatHunter.Crawler.Core.Rightmove;

public interface IRightmoveResultsPage : IWebPage
{
    int GetPageCount();
    IRightmoveResultsPage GoToPage(int page);
    IEnumerable<string> GetAdvertLinks();
    IEnumerable<string> GetCompanies();
}