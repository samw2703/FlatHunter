using BaseCLI;

namespace FlatHunter.Console;

internal class FindNew : ICommand<FindNewArgs>
{
    private readonly ConfigService _configService;
    private readonly IEnumerable<IPropertyFinder> _propertyFinders;

    public FindNew(ConfigService configService, IEnumerable<IPropertyFinder> propertyFinders)
    {
        _configService = configService;
        _propertyFinders = propertyFinders;
    }

    public async Task Execute(FindNewArgs args)
    {
        foreach (var propertyFinder in _propertyFinders)
        {
            await propertyFinder.Find();
        }
        throw new NotImplementedException();
    }

    public string Name => "find-new";
    public string Description => "Finds new properties";

    public ArgInfoCollection<FindNewArgs> ArgInfoCollection => new ArgInfoBuilder<FindNewArgs>()
        .Build();
}

internal class FindNewArgs{}