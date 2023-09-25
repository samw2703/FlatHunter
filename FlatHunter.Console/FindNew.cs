using BaseCLI;
using FlatHunter.Console.PropertyFinders;
using FlatHunter.Core;
using System.Diagnostics;

namespace FlatHunter.Console;

internal class FindNew : ICommand<FindNewArgs>
{
    private readonly ConfigService _configService;
    private readonly IEnumerable<IPropertyFinder> _propertyFinders;
    private readonly IEnumerable<IOneHitPropertyFinder> _oneHitPropertyFinders;
    private readonly IPropertyRepository _propertyRepository;
    private readonly ExceptionStore _exceptionStore;

    public FindNew(ConfigService configService, IEnumerable<IPropertyFinder> propertyFinders, IPropertyRepository propertyRepository, 
        ExceptionStore exceptionStore, IEnumerable<IOneHitPropertyFinder> oneHitPropertyFinders)
    {
        _configService = configService;
        _propertyFinders = propertyFinders;
        _propertyRepository = propertyRepository;
        _exceptionStore = exceptionStore;
        _oneHitPropertyFinders = oneHitPropertyFinders;
    }

    public async Task Execute(FindNewArgs args)
    {
        try
        {
            var properties = await FindAllProperties();

            _exceptionStore.Exceptions.ForEach(System.Console.WriteLine);

            var newProperties = (await FilterExistingProperties(properties)).ToList();

            await Save(newProperties);

            var urls = newProperties.Select(x => x.Url).ToList();
            urls.ForEach(System.Console.WriteLine);
            OpenTabs(urls);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }


    }

    private void OpenTabs(IEnumerable<string> urls)
    {
        string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

        foreach (string url in urls)
        {
            Process.Start(chromePath, url);
        }
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

    private async Task<IEnumerable<Property>> FindAllProperties()
    {
        var propertyFinders = _propertyFinders.ToArray();
        var results = new List<Property>();

        var batchCount = Math.Ceiling((decimal)_propertyFinders.Count() / 2);

        for (int i = 0; i < batchCount; i++)
        {
            var task1 = FindAllProperties(_propertyFinders.ElementAt(i * 2));
            var task2Index = (i * 2) + 1;
            var task2 = (i * 2) + 1 < propertyFinders.Length
                ? FindAllProperties(_propertyFinders.ElementAt(task2Index))
                : Task.FromResult(new List<Property>().AsEnumerable());
            await Task.WhenAll(task1, task2);
            results.AddRange(task1.Result);
            results.AddRange(task2.Result);
        }

        foreach (var oneHitPropertyFinder in _oneHitPropertyFinders)
        {
            results.AddRange(await oneHitPropertyFinder.Find());
        }
        
        return results;
    }

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

    public string Name => "find-new";
    public string Description => "Finds new properties";

    public ArgInfoCollection<FindNewArgs> ArgInfoCollection => new ArgInfoBuilder<FindNewArgs>()
        .Build();
}

internal class FindNewArgs{}