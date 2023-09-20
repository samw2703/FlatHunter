namespace FlatHunter.Console;

internal partial class AddEstateAgent
{
    private string CreatePropertyFinderContent(string name)
    {
        return $@"using FlatHunter.Core;

namespace FlatHunter.Console.PropertyFinders;

internal class {name}PropertyFinder : IPropertyFinder
{{

}}";
    }

    private string CreateAbstractResultsPageContent(string name) => $@"namespace FlatHunter.Crawler.Core.{name};

public interface I{name}ResultsPage : IWebPage
{{

}}";

    private string CreateImplementationResultsPageContent(string name) => $@"using FlatHunter.Crawler.Core.{name};
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.{name};

internal class {name}ResultsPage : SeleniumWebPage, I{name}ResultsPage
{{

}}";

    private string CreateAbstractLandingPageContent(string name) => $@"namespace FlatHunter.Crawler.Core.{name};

public interface I{name}LandingPage : IWebPage
{{

}}";

    private string CreateImplementationLandingPageContent(string name) => $@"using FlatHunter.Crawler.Core.{name};
using OpenQA.Selenium;

namespace FlatHunter.Crawler.Selenium.{name};

internal class {name}LandingPage : SeleniumWebPage, I{name}LandingPage
{{

}}";

    private string CreateServiceConfigContent(string name) => $"services.AddScoped<IPropertyFinder, {name}PropertyFinder>();";

    private string CreateHomePageMethodContent(string name) => $"I{name}LandingPage GoTo{name}();";
}