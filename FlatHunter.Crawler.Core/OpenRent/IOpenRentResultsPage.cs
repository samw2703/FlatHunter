namespace FlatHunter.Crawler.Core.OpenRent;

public interface IOpenRentResultsPage : IWebPage
{
    IOpenRentResultsPage AppendToUrl(int distance, int minPrice, int maxPrice, int minBedroom, int maxBedroom);
    IOpenRentResultsPage ScrollRightToBottom();
    IEnumerable<string> GetLinks();
}