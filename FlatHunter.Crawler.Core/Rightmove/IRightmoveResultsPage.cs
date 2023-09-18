namespace FlatHunter.Crawler.Core.Rightmove;

public interface IRightmoveResultsPage
{
    int GetPageCount();
    IRightmoveResultsPage GoToPage(int page);
    (IRightmoveResultsPage Page, IEnumerable<string> AdvertLinks) GetAdvertLinks();
}