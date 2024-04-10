using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

public class ConfigurationProvider : IConfiguration
{
    private readonly IConfiguration _configuration;

    public ConfigurationProvider()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
    }

    public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        throw new NotImplementedException();
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("DefaultConnection");
    }

    public IChangeToken GetReloadToken()
    {
        throw new NotImplementedException();
    }

    public IConfigurationSection GetSection(string key)
    {
        throw new NotImplementedException();
    }
}
