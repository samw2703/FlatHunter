namespace FlatHunter.Crawler.Core.Foxtons;

public interface IFoxtonsResultsPage : IWebPage
{
    IFoxtonsResultsPage AcceptCookies();
    IEnumerable<string> GetLinks();
}