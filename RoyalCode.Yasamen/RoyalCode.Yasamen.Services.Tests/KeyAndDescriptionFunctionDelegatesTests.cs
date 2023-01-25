
using RoyalCode.Yasamen.Commons.Extensions;

namespace RoyalCode.Yasamen.Services.Tests;

public class KeyAndDescriptionFunctionDelegatesTests
{
    [Fact]
    public void GetKeyFunction_MustReturn_Delegate_For_AnyType()
    {
        // act
        var delegate1 = KeyAndDescriptionFunctionDelegates.GetKeyFunction<Model>();

        // assert
        Assert.NotNull(delegate1);
    }

    [Fact]
    public void GetKeyFunction_MustReturn_Delegate_For_IdType()
    {
        // act
        var delegate1 = KeyAndDescriptionFunctionDelegates.GetKeyFunction<Model, int>();

        // assert
        Assert.NotNull(delegate1);
    }

    [Fact]
    public void GetKeyFunction_MustReturn_Delegate_For_NullableIdType()
    {
        // act
        var delegate1 = KeyAndDescriptionFunctionDelegates.GetKeyFunction<Model, int?>();

        // assert
        Assert.NotNull(delegate1);
    }

    [Fact]
    public void GetKeyFunction_MustReturn_Null_For_WrongType()
    {
        // act
        var delegate1 = KeyAndDescriptionFunctionDelegates.GetKeyFunction<Model, string>();

        // assert
        Assert.Null(delegate1);
    }
}

file class Model
{
    public int Id { get; set; }

    public string? Name { get; set; }
}