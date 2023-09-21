using BaseCLI;
using FlatHunter.Console.PropertyFinders;
using FlatHunter.Core;
using FlatHunter.Crawler.Selenium;

namespace FlatHunter.Console;

internal class TestCommand : ICommand<TestArgs>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly ConfigService _configService;

    public TestCommand(IPropertyRepository propertyRepository, ConfigService configService)
    {
        _propertyRepository = propertyRepository;
        _configService = configService;
    }

    public async Task Execute(TestArgs args)
    {
        try
        {
            var propertyFinder = new ChestertonsPropertyFinder();
            await InitData(propertyFinder);
            //var test = await propertyFinder.Find("n5");
            System.Console.WriteLine();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }
        System.Console.WriteLine("hey");
    }

    public string Name => "Test";
    public string Description => "Test";

    public ArgInfoCollection<TestArgs> ArgInfoCollection => new ArgInfoBuilder<TestArgs>()
        .Build();

    private async Task InitData(IPropertyFinder propertyFinder)
    {
        var properties = await FindAllProperties(propertyFinder);
        var newProperties = await FilterExistingProperties(properties);

        System.Console.WriteLine($"Initialized {newProperties.Count()} records");

        await Save(newProperties);
    }

    private async Task Save(IEnumerable<Property> properties)
    {
        foreach (var property in properties)
        {
            await _propertyRepository.Save(property);
        }
    }

    private async Task<IEnumerable<Property>> FilterExistingProperties(IEnumerable<Property> properties)
    {
        var existingProperties = await _propertyRepository.Get();
        return properties
            .Where(property => !existingProperties.Any(x => AreSame(x, property)));
    }

    private static bool AreSame(Property property1, Property property2)
        => property1.EstateAgent == property2.EstateAgent && property1.Url == property2.Url;

    private async Task<IEnumerable<Property>> FindAllProperties(IPropertyFinder propertyFinder)
    {
        var results = new List<Property>();
        var postcodes = (await _configService.Get()).Postcodes;
        foreach (var postcode in postcodes)
        {
            var postcodeResults = (await propertyFinder.Find(postcode)).DistinctBy(x => x.Url);
            results.AddRange(postcodeResults);
        }

        return results;
    }
}

internal class TestArgs {}