using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium;

internal static class WebDriverExtensions
{
    public static IWebElement? TryFindElement(this IWebDriver webDriver, By by)
    {
        try
        {
            return webDriver.FindElement(by);
        }
        catch (NoSuchElementException)
        {
            return null;
        }
    }
}