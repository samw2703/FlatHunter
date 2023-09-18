namespace FlatHunter.Core;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> Get();
    Task Save(Property property);
}