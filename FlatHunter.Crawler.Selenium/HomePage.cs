using FlatHunter.Crawler.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FlatHunter.Crawler.Selenium;

internal class HomePage : IHomePage
{
    private readonly IWebDriver _webDriver;

    public HomePage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void Test()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-extensions");
        _webDriver.Navigate().GoToUrl("https://www.rightmove.co.uk/");

        IWebElement searchBox = _webDriver.FindElement(By.CssSelector("#searchLocation"));

        searchBox.Clear();
        searchBox.SendKeys("London");

        IWebElement toRentButton = _webDriver.FindElement(By.CssSelector("#buy > a"));
        toRentButton.Click();
    }
}