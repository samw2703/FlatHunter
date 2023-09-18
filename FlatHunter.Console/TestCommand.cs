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
        //var task1 = Search("n19");
        //var task2 = Search("n5");
        //await Task.WhenAll(task1, task2);git
        var property = new Property
        {
            EstateAgent = EstateAgents.Rightmove,
            Found = DateTime.Now,
            Url = "hellllo2"
        };
        await _propertyRepository.Save(property);
    }

    public string Name => "Test";
    public string Description => "Test";

    public ArgInfoCollection<TestArgs> ArgInfoCollection => new ArgInfoBuilder<TestArgs>()
        .Build();

    private Task Search(string area)
    {
        return Task.Run(() => WebBrowser.Launch()
            .GoToRightmove()
            .RejectCookies()
            .EnterSearch(area)
            .ClickToRent());
    }
}

internal class TestArgs {}