using BaseCLI;

namespace FlatHunter.Console;

internal partial class AddEstateAgent : ICommand<AddEstateAgentArgs>
{
    private const string ProjectPath = "C:\\Informal\\Projects\\FlatHunter\\src";

    public async Task Execute(AddEstateAgentArgs args)
    {
        await AddPropertyFinder(args.Name);
        await AddPageClasses(args.Name);
    }

    private async Task AddPropertyFinder(string name)
    {
        var path = CreateFullPath("FlatHunter.Console\\PropertyFinders", $"{name}PropertyFinder.cs");
        var content = CreatePropertyFinderContent(name);
        await File.WriteAllTextAsync(path, content);
        PrintTips(name);
    }

    private async Task AddPageClasses(string name)
    {
        await AddAbstractPageClasses(name);
        await AddImplementationPageClasses(name);
    }

    private async Task AddAbstractPageClasses(string name)
    {
        var relativeDirectory = $"FlatHunter.Crawler.Core\\{name}";
        Directory.CreateDirectory(CreateFullPath(relativeDirectory));

        var landingPagePath = CreateFullPath(relativeDirectory, $"I{name}LandingPage.cs");
        var landingPageContent = CreateAbstractLandingPageContent(name);
        await File.WriteAllTextAsync(landingPagePath, landingPageContent);

        var resultsPagePath = CreateFullPath(relativeDirectory, $"I{name}ResultsPage.cs");
        var resultsPageContent = CreateAbstractResultsPageContent(name);
        await File.WriteAllTextAsync(resultsPagePath, resultsPageContent);
    }

    private async Task AddImplementationPageClasses(string name)
    {
        var relativeDirectory = $"FlatHunter.Crawler.Selenium\\{name}";
        Directory.CreateDirectory(CreateFullPath(relativeDirectory));

        var landingPagePath = CreateFullPath(relativeDirectory, $"{name}LandingPage.cs");
        var landingPageContent = CreateImplementationLandingPageContent(name);
        await File.WriteAllTextAsync(landingPagePath, landingPageContent);

        var resultsPagePath = CreateFullPath(relativeDirectory, $"{name}ResultsPage.cs");
        var resultsPageContent = CreateImplementationResultsPageContent(name);
        await File.WriteAllTextAsync(resultsPagePath, resultsPageContent);
    }

    private void PrintTips(string name)
    {
        System.Console.WriteLine(CreateServiceConfigContent(name));
        System.Console.WriteLine(CreateHomePageMethodContent(name));
    }

    private string CreateFullPath(string relativePath, string fileName = "") => Path.Combine(ProjectPath, relativePath, fileName);

    public string Name => "add-estate-agent";
    public string Description => "Adds all the necessary classes for adding a new estate agent";

    public ArgInfoCollection<AddEstateAgentArgs> ArgInfoCollection => new ArgInfoBuilder<AddEstateAgentArgs>()
        .Add("n", "Name").ForMandatoryString(x => x.Name)
        .Build();
}

internal class AddEstateAgentArgs
{
    public string Name { get; set; }
}