﻿// See https://aka.ms/new-console-template for more information

using BaseCLI;
using FlatHunter.Console;
using FlatHunter.Core.Json;
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
    services.AddScoped<IPropertyFinder, NoPropertyFinder>();
    services.AddScoped<IPropertyFinder, RightmovePropertyFinder>();
}