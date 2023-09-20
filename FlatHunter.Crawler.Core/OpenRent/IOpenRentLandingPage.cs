namespace FlatHunter.Crawler.Core.OpenRent;

public interface IOpenRentLandingPage : IWebPage
{
    IOpenRentLandingPage EnterSearch(string text);
    IOpenRentResultsPage ClickSearch();
}