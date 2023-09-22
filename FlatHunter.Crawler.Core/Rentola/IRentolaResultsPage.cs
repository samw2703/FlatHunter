namespace FlatHunter.Crawler.Core.Rentola;

public interface IRentolaResultsPage : IWebPage
{
    IRentolaResultsPage AppendToUrl(int maxPrice, int minRooms, int maxRooms);
    IRentolaResultsPage LoadAllResults();
    IEnumerable<string> GetLinks();
}