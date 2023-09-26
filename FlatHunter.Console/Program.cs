using BaseCLI;
using FlatHunter.Console;
using FlatHunter.Console.PropertyFinders;
using FlatHunter.Core.Json;
using FlatHunter.Crawler.Core.Foxtons;
using Microsoft.Extensions.DependencyInjection;


await CLI.Execute(args, new[] { typeof(TestArgs).Assembly }, AddServices);

void AddServices(IServiceCollection services)
{
    services.AddScoped<ConfigService>();
    AddPropertyFinders(services);
    AddOneHitPropertyFinders(services);
    services.AddJsonServices();
    services.AddScoped<ExceptionStore>();
}

void AddPropertyFinders(IServiceCollection services)
{
    services.AddScoped<IPropertyFinder, RightmovePropertyFinder>();
    services.AddScoped<IPropertyFinder, OpenRentPropertyFinder>();
    services.AddScoped<IPropertyFinder, SpareroomPropertyFinder>();
    services.AddScoped<IPropertyFinder, DextersPropertyFinder>();
    services.AddScoped<IPropertyFinder, KinleighPropertyFinder>();
    services.AddScoped<IPropertyFinder, ChestertonsPropertyFinder>();
    services.AddScoped<IPropertyFinder, RentolaPropertyFinder>();
    services.AddScoped<IPropertyFinder, OnTheMarketPropertyFinder>();
    //services.AddScoped<IPropertyFinder, ZooplaPropertyFinder>();
    services.AddScoped<IPropertyFinder, FoxtonsPropertyFinder>();
    services.AddScoped<IPropertyFinder, DavidAndrewPropertyFinder>();
    services.AddScoped<IPropertyFinder, DavidAstburyPropertyFinder>();
    services.AddScoped<IPropertyFinder, JeremyLeafPropertyFinder>();
}

void AddOneHitPropertyFinders(IServiceCollection services)
{
    services.AddScoped<IOneHitPropertyFinder, StonehousePropertyFinder>();
    services.AddScoped<IOneHitPropertyFinder, BurghleysPropertyFinder>();
    services.AddScoped<IOneHitPropertyFinder, BlackKatzPropertyFinder>();
}