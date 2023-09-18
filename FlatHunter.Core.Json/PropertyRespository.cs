using Newtonsoft.Json;

namespace FlatHunter.Core.Json;

internal class PropertyRespository : IPropertyRepository
{
    private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties.json");

    public async Task<IEnumerable<Property>> Get() => File.Exists(_filePath)
            ? JsonConvert.DeserializeObject<List<Property>>(await File.ReadAllTextAsync(_filePath))
            : new List<Property>();
    
    public async Task Save(Property property)
    {
        var properties = (await Get()).ToList();
        var test = GetUniqueIdentifier(property);
        var existingProperty = properties.SingleOrDefault(x => GetUniqueIdentifier(x) == GetUniqueIdentifier(property));
        if (existingProperty == null)
            properties.Add(property);
        else
        {
            properties.Remove(existingProperty);
            properties.Add(property);
        }
        await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(properties));
    }

    private string GetUniqueIdentifier(Property property)
        => JsonConvert.SerializeObject((property.EstateAgent, property.Url));
}