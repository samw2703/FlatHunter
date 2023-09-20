using BaseCLI;
using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console;

internal class TestCommand : ICommand<TestArgs>
{
    private readonly IPropertyRepository _propertyRepository;

    public TestCommand(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task Execute(TestArgs args)
    {
        System.Console.WriteLine("hey");
    }

    public string Name => "Test";
    public string Description => "Test";

    public ArgInfoCollection<TestArgs> ArgInfoCollection => new ArgInfoBuilder<TestArgs>()
        .Build();

    private IEnumerable<string> Search(string area)
    {
        var results = new List<string>();
        var page = WebBrowser.Launch().GoToRightmove()
            .RejectCookies().EnterSearch(area).ClickToRent()
            .SetMinBedrooms(3).SetMaxBedrooms(3)
            .SetMaxPrice(3500).ClickFindProperties();
        var count = page.GetPageCount();
        results.AddRange(page.GetCompanies());
        for (int i = 2; i <= count; i++)
        {
            page = page.GoToPage(i);
            results.AddRange(page.GetCompanies());
        }

        page.CloseBrowser();
        return results;
    }
}

internal class TestArgs {}