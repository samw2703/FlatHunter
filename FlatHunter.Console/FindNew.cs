using BaseCLI;
using FlatHunter.Core;
using System.Diagnostics;

namespace FlatHunter.Console;

internal class FindNew : ICommand<FindNewArgs>
{
    private readonly ConfigService _configService;
    private readonly IEnumerable<IPropertyFinder> _propertyFinders;
    private readonly IPropertyRepository _propertyRepository;

    public FindNew(ConfigService configService, IEnumerable<IPropertyFinder> propertyFinders, IPropertyRepository propertyRepository)
    {
        _configService = configService;
        _propertyFinders = propertyFinders;
        _propertyRepository = propertyRepository;
    }

    public async Task Execute(FindNewArgs args)
    {
        var properties = await FindAllProperties();
        var newProperties = (await FilterExistingProperties(properties)).ToList();

        await Save(newProperties);

        var urls = newProperties.Select(x => x.Url).ToList();
        urls.ForEach(System.Console.WriteLine);
        OpenTabs(urls);
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
        var postcodes = (await _configService.Get()).Postcodes;
        var results = new List<Property>();
        foreach (var propertyFinder in _propertyFinders)
        {
            foreach (var postcode in postcodes)
            {
                try
                {
                    var postcodeResults = (await propertyFinder.Find(postcode)).DistinctBy(x => x.Url);
                    results.AddRange(postcodeResults);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                    throw;
                }
            }
        }

        return results;
    }

    public string Name => "find-new";
    public string Description => "Finds new properties";

    public ArgInfoCollection<FindNewArgs> ArgInfoCollection => new ArgInfoBuilder<FindNewArgs>()
        .Build();
}

internal class FindNewArgs{}