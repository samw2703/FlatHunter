using Newtonsoft.Json;

public class ConfigService
{
    private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.json");

    public async Task<Config> Get() => File.Exists(_filePath)
        ? JsonConvert.DeserializeObject<Config>(await File.ReadAllTextAsync(_filePath))
        : new Config();

    public Task Save(Config config) => File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(config));
}

public class Config
{
    public List<string> Postcodes { get; set; } = new();
    public string ChromePath { get; set; }
    public string ChromeDriverPath { get; set; }
}
