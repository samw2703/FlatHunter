using FlatHunter.Crawler.Core;
using OpenQA.Selenium.Chrome;

namespace FlatHunter.Crawler.Selenium;

public static class WebBrowser
{
    public static IHomePage Launch()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-extensions");
        return new HomePage(new ChromeDriver(@"C:\Users\samw2\Desktop\chromedriver.exe", options));
    }
}