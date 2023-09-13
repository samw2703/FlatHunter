using FlatHunter.Crawler.Core;
using OpenQA.Selenium.Chrome;

namespace FlatHunter.Crawler.Selenium;

public static class WebBrowser
{
    public static IHomePage Launch()
    {
        return new HomePage(new ChromeDriver("C:\\Users\\samw2\\Desktop\\chromedriver.exe"));
    }
}