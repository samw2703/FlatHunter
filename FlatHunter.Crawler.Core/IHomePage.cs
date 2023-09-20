using FlatHunter.Crawler.Core.Dexters;
using FlatHunter.Crawler.Core.OpenRent;
using FlatHunter.Crawler.Core.Rightmove;
using FlatHunter.Crawler.Core.Spareroom;

namespace FlatHunter.Crawler.Core;

public interface IHomePage : IWebPage
{
    IRightmoveLandingPage GoToRightmove();
    IOpenRentLandingPage GoToOpenRent();
    ISpareroomLandingPage GoToSpareroom();
    IDextersLandingPage GoToDexters();
}