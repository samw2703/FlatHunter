using FlatHunter.Core;

namespace FlatHunter.Console.PropertyFinders;

internal interface IOneHitPropertyFinder
{
    Task<IEnumerable<Property>> Find();
}