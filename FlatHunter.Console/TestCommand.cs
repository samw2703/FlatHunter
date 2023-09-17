using BaseCLI;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console;

internal class TestCommand : ICommand<TestArgs>
{
    public async Task Execute(TestArgs args)
    {
        var task1 = Search("n19");
        var task2 = Search("n5");
        await Task.WhenAll(task1, task2);
    }

    public string Name { get; } = "Test";
    public string Description { get; } = "Test";

    public ArgInfoCollection<TestArgs> ArgInfoCollection { get; } = new ArgInfoBuilder<TestArgs>()
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