﻿using BaseCLI;
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
            //await TestTest();




            var propertyFinder = new JTMHomesPropertyFinder(new ExceptionStore());
            await InitData(propertyFinder);
            //var test = (await propertyFinder.Find("n19")).ToList();




            //var oneHitPropertyFinder = new StonehousePropertyFinder(new ExceptionStore());
            //await InitData(oneHitPropertyFinder);
            //var test = (await oneHitPropertyFinder.Find()).ToList();
            System.Console.WriteLine();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }
        System.Console.WriteLine("hey");
    }

    private async Task TestTest()
    {
        var finder1 = new BlackKatzPropertyFinder(new ExceptionStore());
        var finder2 = new BurghleysPropertyFinder(new ExceptionStore());
        var finder3 = new DavidAstburyPropertyFinder(new ExceptionStore());
        var finder4 = new JeremyLeafPropertyFinder(new ExceptionStore());

        //var test1 = (await finder1.Find()).ToList();
        //var test2 = (await finder2.Find()).ToList();
        //var test3 = (await finder3.Find("n8")).ToList();
        //var test4 = (await finder4.Find("n2")).ToList();

        await InitData(finder1);
        await InitData(finder2);
        await InitData(finder3);
        await InitData(finder4);

        System.Console.WriteLine();
    }

    public string Name => "Test";
    public string Description => "Test";

    public ArgInfoCollection<TestArgs> ArgInfoCollection => new ArgInfoBuilder<TestArgs>()
        .Build();

    private async Task InitData(IOneHitPropertyFinder oneHitPropertyFinder)
    {
        var properties = await oneHitPropertyFinder.Find();
        var newProperties = await FilterExistingProperties(properties);

        System.Console.WriteLine($"Initialized {newProperties.Count()} records");

        await Save(newProperties);
    }

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