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
        options.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36");
        return new HomePage(new ChromeDriver(@"C:\Users\samw2\Desktop\chromedriver.exe", options));
    }
}