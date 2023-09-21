namespace FlatHunter.Crawler.Core.Chestertons;

public interface IChestertonsResultsPage : IWebPage
{
    int GetPageCount();
    IChestertonsResultsPage GoToPage(int page);
    IEnumerable<string> GetLinks();
}