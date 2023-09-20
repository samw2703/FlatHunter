﻿using FlatHunter.Crawler.Core;
using FlatHunter.Crawler.Core.OpenRent;
using FlatHunter.Crawler.Core.Rightmove;
using FlatHunter.Crawler.Selenium.OpenRent;
using FlatHunter.Crawler.Selenium.Rightmove;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium;

internal class HomePage : SeleniumWebPage, IHomePage
{
    public HomePage(IWebDriver webDriver) 
        : base(webDriver, LoadWaitArgs.UntilExists(By.CssSelector("")))
    {
    }

    public IRightmoveLandingPage GoToRightmove()
        => GoTo("https://www.rightmove.co.uk/", x => new RightmoveLandingPage(x));

    public IOpenRentLandingPage GoToOpenRent()
        => GoTo("https://www.openrent.co.uk/", x => new OpenRentLandingPage(x));
}