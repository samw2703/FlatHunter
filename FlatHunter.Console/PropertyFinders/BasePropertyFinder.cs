using FlatHunter.Core;
using System;

namespace FlatHunter.Console.PropertyFinders;

internal abstract class BasePropertyFinder : IPropertyFinder
{
    private readonly ExceptionStore _exceptionStore;

    protected BasePropertyFinder(ExceptionStore exceptionStore)
    {
        _exceptionStore = exceptionStore;
    }

    public async Task<IEnumerable<Property>> Find(string postCode)
    {
        try
        {
            return await DoFind(postCode);
        }
        catch (Exception e)
        {
            _exceptionStore.Add(e);
            return new List<Property>();
        }
    }

    protected abstract Task<IEnumerable<Property>> DoFind(string postCode);
}