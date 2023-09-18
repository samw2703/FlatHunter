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
        var postcodes = new List<string>
        {
            "n4",
            "n19",
            "n7",
            "n6",
            "n8",
            "nw5",
            "n1",
            "n5",
            "n10",
            "nw3",
        };

        postcodes.SelectMany(Search)
            .GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .ToList()
            .ForEach(x => System.Console.WriteLine($"company: {x.Key}; count: {x.Count()}"));

        //var task1 = Search("n19");
        //var task2 = Search("n5");
        //await Task.WhenAll(task1, task2);git
        //var property = new Property
        //{
        //    EstateAgent = EstateAgents.Rightmove,
        //    Found = DateTime.Now,
        //    Url = "hellllo2"
        //};
        //await _propertyRepository.Save(property);
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

        page.Close();
        return results;
    }
}

internal class TestArgs {}