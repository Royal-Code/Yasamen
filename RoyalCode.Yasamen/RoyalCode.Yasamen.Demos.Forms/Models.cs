using RoyalCode.OperationResult;
using RoyalCode.Yasamen.Forms.Validation;
using RoyalCode.Yasamen.Services;
using System.ComponentModel;

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

    public IOperationResult Validate(Friend model)
    {
        if (!Failure)
            return BaseResult.ImmutableSuccess;

        return BaseResult.CreateSuccess()
            .WithError("Your friend will always have failures.")
            .WithInfo("But you can still be happy.")
            .WithError("This is a bad name", nameof(Friend.Name))
            .WithError("This is a dangerous email", nameof(Friend.EMail))
            .WithError("This not a fine phone number", nameof(Friend.Phone))
            .WithError("Check or not, you got a problem", nameof(Friend.IsActive));
    }
}

public class CityService
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
    public async Task<IEnumerable<City>> GetCities()
    {
        await Task.Delay(3_000);
        return cities;
    }
}

public class CarService
{
    private static readonly List<Car> cars = new List<Car>
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
    public async Task<IEnumerable<Car>> GetCars()
    {
        await Task.Delay(3_000);
        return cars;
    }
}