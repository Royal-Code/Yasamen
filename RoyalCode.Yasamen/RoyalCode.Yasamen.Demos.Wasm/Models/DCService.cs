using RoyalCode.Yasamen.Services.Attributes;
using System.Net.Http.Json;

namespace RoyalCode.Yasamen.Demos.Wasm.Models;

public class DCService
{
    private readonly HttpClient http;
    private IEnumerable<DistributionCenter>? distributionCenters;

    public DCService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<IEnumerable<DistributionCenter>> GetAllDistributionCentersAsync()
    {
        return distributionCenters ??= (await http.GetFromJsonAsync<DistributionCenter[]>("sample-data/dc.json"))!;
    }

    [Finder]
    public async Task<DistributionCenter?> GetDistributionCenterByNumberAsync(string number)
    {
        var dcs = await GetAllDistributionCentersAsync();
        return dcs.FirstOrDefault(d => d.Number == number);
    }

    [Finder]
    public async Task<Warehouse?> GetWarehouseByNumbersAsync(WarehouseNumbers numbers)
    {
        var dc = await GetDistributionCenterByNumberAsync(numbers.DistributionCenterNumber);
        return dc?.Warehouses.FirstOrDefault(w => w.Number == numbers.WarehouseNumber);
    }

    [Finder]
    public async Task<Area?> GetAreaByNumbersAsync(AreaNumbers numbers)
    {
        var wh = await GetWarehouseByNumbersAsync(numbers);
        return wh?.Areas.FirstOrDefault(a => a.Number == numbers.AreaNumber);
    }

    [Finder]
    public async Task<Address?> GetAddressByNumbersAsync(AddressNumbers numbers)
    {
        var area = await GetAreaByNumbersAsync(numbers);
        return area?.Addresses.FirstOrDefault(a => a.Number == numbers.AddressNumber);
    }
}