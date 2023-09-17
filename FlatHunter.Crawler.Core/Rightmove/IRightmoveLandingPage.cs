namespace FlatHunter.Crawler.Core.Rightmove;

public interface IRightmoveLandingPage
{
    IRightmoveLandingPage RejectCookies();
    IRightmoveLandingPage EnterSearch(string search);
    IRightmoveFilterPage ClickToRent();
}