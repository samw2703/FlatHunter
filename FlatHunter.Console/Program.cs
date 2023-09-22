using BaseCLI;
using FlatHunter.Console;
using FlatHunter.Console.PropertyFinders;
using FlatHunter.Core.Json;
using FlatHunter.Crawler.Core.Chestertons;
using FlatHunter.Crawler.Core.Dexters;
using FlatHunter.Crawler.Core.Kinleigh;
using FlatHunter.Crawler.Core.Rentola;
using FlatHunter.Crawler.Core.Spareroom;
using Microsoft.Extensions.DependencyInjection;


await CLI.Execute(args, new[] { typeof(TestArgs).Assembly }, AddServices);

void AddServices(IServiceCollection services)
{
    services.AddScoped<ConfigService>();
    AddPropertyFinders(services);
    services.AddJsonServices();
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
}