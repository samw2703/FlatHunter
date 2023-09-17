using FlatHunter.Crawler.Core.Rightmove;
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.Rightmove;

internal class RightmoveLandingPage: SeleniumWebPage, IRightmoveLandingPage
{
    public RightmoveLandingPage(IWebDriver webDriver) 
        : base(webDriver, LoadWaitArgs.UntilExists(By.Id("onetrust-reject-all-handler")))
    {
    }

    public IRightmoveLandingPage RejectCookies()
    {
        Click(By.Id("onetrust-reject-all-handler"));
        return this;
    }

    public IRightmoveLandingPage EnterSearch(string search)
    {
        EnterText(By.CssSelector(".ksc_inputText.ksc_typeAheadInputField"), search);
        return this;
    }

    public IRightmoveFilterPage ClickToRent()
        => ClickNavigate(By.CssSelector(".ksc_button.large.primary.searchPanelControls:nth-child(3)"), x => new RightmoveFilterPage(x));
}