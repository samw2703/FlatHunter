using FlatHunter.Core;

namespace FlatHunter.Console.PropertyFinders;

internal class NoPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find(string postCode)
    {
        return Task.FromResult(new List<Property>().AsEnumerable());
    }
}