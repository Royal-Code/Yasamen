using RoyalCode.OperationResults;
using RoyalCode.Yasamen.Forms.Validation;
using RoyalCode.Yasamen.Services;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Demos.Forms;

public class Friend
{
    public string? Name { get; set; }

    public string? EMail { get; set; }

    public string? Phone { get; set; }

    public int Age { get; set; } = 18;

    public decimal Weight { get; set; }

    public bool IsActive { get; set; } = true;

    public FriendType Type { get; set; }

    public Vip? Vip { get; set; }

    public int CityId { get; set; }

    public int? AlterCityId { get; set; }

    public Car Car { get; set; }

    public DateOnly LastMeeting { get; set; }

    public DateOnly? NextMetting { get; set; }

    public DateTime LastCall { get; set; } = DateTime.Now.AddYears(-1);
}


public enum FriendType
{
    [Description("Amigo")]
    Friend,

    [Description("Inimigo")]
    Enemy,

    [Description("Desconhecido")]
    Stranger
}

public enum Vip
{
    Silver,
    Gold,
    Platinum
}

public class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}

public class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}

public class ValidadorFriend : IValidator<Friend>
{
    public bool Failure { get; set; }

    public ValidableResult Validate(Friend model)
    {
        var result = new ValidableResult();

        if (!Failure)
            return result;

        result += ResultMessage.Error("Your friend will always have failures.");
        result += ResultMessage.Error("But you can still be happy.");
        result += ResultMessage.Error("This is a bad name", nameof(Friend.Name));
        result += ResultMessage.Error("This is a dangerous email", nameof(Friend.EMail));
        result += ResultMessage.Error("This not a fine phone number", nameof(Friend.Phone));
        result += ResultMessage.Error("Check or not, you got a problem", nameof(Friend.IsActive));

        return result;
    }
}

public class CityService
{
    private static readonly List<City> cities = new()
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
        new City()
        {
            Id = 4,
            Name = "Salvador"
        },
        new City()
        {
            Id = 5,
            Name = "Fortaleza"
        },
        new City()
        {
            Id = 6,
            Name = "Brasília"
        },
        new City()
        {
            Id = 7,
            Name = "Curitiba"
        },
        new City()
        {
            Id = 8,
            Name = "Recife"
        },
        new City()
        {
            Id = 9,
            Name = "Manaus"
        },
        new City()
        {
            Id = 10,
            Name = "Belém"
        }
    };

    [Loader]
    public async Task<IReadOnlyList<City>> GetCities()
    {
        await Task.Delay(3_000);
        return cities;
    }
}

public class CarService
{
    private static readonly List<Car> cars = new()
    {
        new Car()
        {
            Id = 1,
            Name = "Ferrari"
        },
        new Car()
        {
            Id = 2,
            Name = "Lamborghini"
        },
        new Car()
        {
            Id = 3,
            Name = "Porsche"
        },
        new Car()
        {
            Id = 4,
            Name = "Audi"
        },
        new Car()
        {
            Id = 5,
            Name = "BMW"
        },
        new Car()
        {
            Id = 6,
            Name = "Mercedes-Benz"
        },
        new Car()
        {
            Id = 7,
            Name = "Volkswagen"
        },
        new Car()
        {
            Id = 8,
            Name = "Toyota"
        },
        new Car()
        {
            Id = 9,
            Name = "Honda"
        },
        new Car()
        {
            Id = 10,
            Name = "Hyundai"
        }
    };

    [Loader]
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Loader can't be static")]
    public async Task<IReadOnlyList<Car>> GetCars()
    {
        await Task.Delay(3_000);
        return cars;
    }
}