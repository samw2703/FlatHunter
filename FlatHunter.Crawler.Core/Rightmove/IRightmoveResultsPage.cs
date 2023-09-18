namespace FlatHunter.Crawler.Core.Rightmove;

public interface IRightmoveResultsPage
{
    int GetPageCount();
    IRightmoveResultsPage GoToPage(int page);
    IEnumerable<string> GetAdvertLinks();
    IEnumerable<string> GetCompanies();
    void Close();
}