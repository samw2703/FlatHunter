using FlatHunter.Core;

namespace FlatHunter.Console.PropertyFinders;

internal interface IPropertyFinder
{
    Task<IEnumerable<Property>> Find(string postCode);
}