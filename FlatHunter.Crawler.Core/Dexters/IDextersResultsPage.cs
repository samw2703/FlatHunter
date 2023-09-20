using FlatHunter.Crawler.Core.OpenRent;

namespace FlatHunter.Crawler.Core.Dexters;

public interface IDextersResultsPage : IWebPage
{
    IDextersResultsPage GoToUrl(int minPrice, int maxPrice, int bedrooms, string postCode);
    IEnumerable<string> GetLinks();
}