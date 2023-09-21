namespace FlatHunter.Crawler.Core.Chestertons;

public interface IChestertonsLandingPage : IWebPage
{
    IChestertonsLandingPage AcceptCookies();
    IChestertonsResultsPage GoToResults(string postCode, int minPrice, int maxPrice, int minBedrooms, int maxBedrooms);
}