using BaseCLI;

namespace FlatHunter.Console;

internal class CreateConfig : ICommand<CreateConfigArgs>
{
    private readonly ConfigService _configService;

    public CreateConfig(ConfigService configService)
    {
        _configService = configService;
    }

    public async Task Execute(CreateConfigArgs args)
    {
        var config = await _configService.Get();
        await _configService.Save(config);
    }

    public string Name => "create-config";
    public string Description => "Creates new config file if one doesn't exist";
    public ArgInfoCollection<CreateConfigArgs> ArgInfoCollection => new ArgInfoBuilder<CreateConfigArgs>().Build();

}

internal class CreateConfigArgs {}