using Microsoft.Extensions.DependencyInjection;

namespace RoyalCode.Yasamen.Forms.Validation;

public interface IValidatorProvider
{
    IValidator<TModel>? GetValidator<TModel>();
}

public class ValidatorProvider : IValidatorProvider
{
    private readonly IServiceProvider serviceProvider;

    public ValidatorProvider(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IValidator<TModel>? GetValidator<TModel>()
    {
        return serviceProvider.GetService<IValidator<TModel>>();
    }
}