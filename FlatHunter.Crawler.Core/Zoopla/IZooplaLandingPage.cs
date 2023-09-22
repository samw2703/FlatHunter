namespace FlatHunter.Crawler.Core.Zoopla;

public interface IZooplaLandingPage : IWebPage
{
    IZooplaLandingPage AcceptCookies();
    IZooplaLandingPage ClickToRent();
    IZooplaLandingPage EnterSearch(string text);
    IZooplaResultsPage ClickSearch();
}