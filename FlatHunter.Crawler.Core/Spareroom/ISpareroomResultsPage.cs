namespace FlatHunter.Crawler.Core.Spareroom;

public interface ISpareroomResultsPage : IWebPage
{
    ISpareroomResultsPage SetMinPrice(int value);
    ISpareroomResultsPage SetMaxPrice(int value);
    ISpareroomResultsPage RemoveExistingShares();
    ISpareroomResultsPage RemoveStudios();
    ISpareroomResultsPage ClickApplyFilters();
    IEnumerable<string> GetLinks();
}