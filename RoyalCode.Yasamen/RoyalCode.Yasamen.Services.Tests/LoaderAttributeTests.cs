using Microsoft.Extensions.DependencyInjection;

namespace RoyalCode.Yasamen.Services.Tests;

public class LoaderAttributeTests
{
    [Fact]
    public void AddServices_MustRegister_LoaderDelegate_And_LoaderPerformer()
    {
        // Arrange
        var services = new ServiceCollection();
        var attribute = new LoaderAttribute();
        var method = typeof(CityServices).GetMethod(nameof(CityServices.GetCities))!;

        // Act
        attribute.AddServices(services, method);

        // Assert
        var loaderDelegateDescriptor = services.FirstOrDefault(d => d.ServiceType?.Name.StartsWith("LoaderDelegate") == true);
        Assert.NotNull(loaderDelegateDescriptor);
        
        var loaderPerformerDescriptor = services.FirstOrDefault(d => d.ServiceType?.Name.StartsWith("ILoaderPerformer") == true);
        Assert.NotNull(loaderPerformerDescriptor);
    }
}

file class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}

file class CityServices
{
    private static readonly List<City> cities = new List<City>
    {
        new City()
        {
            Id = 1,
            Name = "São Paulo"
        },
        new City()
        {
            Id = 2,
            Name = "Rio de Janeiro"
        },
        new City()
        {
            Id = 3,
            Name = "Belo Horizonte"
        },
    };

    [Loader]
    public async Task<IEnumerable<City>> GetCities()
    {
        await Task.Delay(1_000);
        return cities;
    }
}