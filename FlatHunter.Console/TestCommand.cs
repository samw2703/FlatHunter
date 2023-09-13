using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCLI;
using FlatHunter.Crawler.Selenium;
using OpenQA.Selenium;

namespace FlatHunter.Console;

internal class TestCommand : ICommand<TestArgs>
{
    public void Execute(TestArgs args)
    {
        WebBrowser.Launch().Test();
    }

    public string Name { get; } = "Test";
    public string Description { get; } = "Test";

    public ArgInfoCollection<TestArgs> ArgInfoCollection { get; } = new ArgInfoBuilder<TestArgs>()
        .Build();
}

internal class TestArgs {}