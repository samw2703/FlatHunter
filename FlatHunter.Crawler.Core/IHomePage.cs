using FlatHunter.Crawler.Core.OpenRent;
using FlatHunter.Crawler.Core.Rightmove;

namespace FlatHunter.Crawler.Core;

public interface IHomePage : IWebPage
{
    IRightmoveLandingPage GoToRightmove();
    IOpenRentLandingPage GoToOpenRent();
}