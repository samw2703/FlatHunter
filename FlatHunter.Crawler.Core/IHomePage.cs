﻿using FlatHunter.Crawler.Core.Chestertons;
using FlatHunter.Crawler.Core.Dexters;
using FlatHunter.Crawler.Core.Foxtons;
using FlatHunter.Crawler.Core.Kinleigh;
using FlatHunter.Crawler.Core.OnTheMarket;
using FlatHunter.Crawler.Core.OpenRent;
using FlatHunter.Crawler.Core.Rentola;
using FlatHunter.Crawler.Core.Rightmove;
using FlatHunter.Crawler.Core.Spareroom;
using FlatHunter.Crawler.Core.Zoopla;

namespace FlatHunter.Crawler.Core;

public interface IHomePage : IWebPage
{
    IRightmoveLandingPage GoToRightmove();
    IOpenRentLandingPage GoToOpenRent();
    ISpareroomLandingPage GoToSpareroom();
    IDextersLandingPage GoToDexters();
    IKinleighResultsPage GoToKinleigh(string postCode, int minPrice, int maxPrice, int bedrooms);
    IChestertonsLandingPage GoToChestertons();
    IRentolaLandingPage GoToRentola();
    IOnTheMarketResultsPage GoToOnTheMarket(string postCode, int minPrice, int maxPrice, int bedrooms);
    IZooplaLandingPage GoToZoopla();
    IFoxtonsResultsPage GoToFoxtons(string postCode);

    IHomePage GoTo(string url);
    IEnumerable<string> GetLinks(string cssSelector);
    void Click(string cssSelector);
}