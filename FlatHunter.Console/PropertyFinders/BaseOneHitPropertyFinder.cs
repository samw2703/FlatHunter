using FlatHunter.Core;

namespace FlatHunter.Console.PropertyFinders;

internal abstract class BaseOneHitPropertyFinder : IOneHitPropertyFinder
{
    private readonly ExceptionStore _exceptionStore;

    protected BaseOneHitPropertyFinder(ExceptionStore exceptionStore)
    {
        _exceptionStore = exceptionStore;
    }

    public async Task<IEnumerable<Property>> Find()
    {
        try
        {
            return await DoFind();
        }
        catch (Exception e)
        {
            _exceptionStore.Add(e);
            return new List<Property>();
        }
    }

    protected abstract Task<IEnumerable<Property>> DoFind();
}