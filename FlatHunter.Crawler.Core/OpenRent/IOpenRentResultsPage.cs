namespace FlatHunter.Crawler.Core.OpenRent;

public interface IOpenRentResultsPage : IWebPage
{
    IOpenRentResultsPage AppendToUrl(int distance, int minPrice, int maxPrice, int minBedroom, int maxBedroom);
    IOpenRentResultsPage SetDistance(int value);
    IOpenRentResultsPage ClickPriceFilter();
    IOpenRentResultsPage SetMinPrice(int value);
    IOpenRentResultsPage SetMaxPrice(int value);
    IOpenRentResultsPage ClickBedFilter();
    IOpenRentResultsPage SetMinBed(int value);
    IOpenRentResultsPage SetMaxBed(int value);
    IOpenRentResultsPage ClickBedUpdate();
    IOpenRentResultsPage ClickSearch();
    IOpenRentResultsPage ScrollRightToBottom();
    IEnumerable<string> GetLinks();
}