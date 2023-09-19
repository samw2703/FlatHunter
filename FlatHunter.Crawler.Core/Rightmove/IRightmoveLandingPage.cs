namespace FlatHunter.Crawler.Core.Rightmove;

public interface IRightmoveLandingPage : IWebPage
{
    IRightmoveLandingPage RejectCookies();
    IRightmoveLandingPage EnterSearch(string search);
    IRightmoveFilterPage ClickToRent();
}