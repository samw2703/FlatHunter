using FlatHunter.Core;

namespace FlatHunter.Console;

internal interface IPropertyFinder
{
    Task<IEnumerable<Property>> Find();
}

internal class NoPropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find()
    {
        return Task.FromResult(new List<Property>().AsEnumerable());
    }
}

internal class RightmovePropertyFinder : IPropertyFinder
{
    public Task<IEnumerable<Property>> Find()
    {
        return Task.FromResult(new List<Property>().AsEnumerable());
    }
}