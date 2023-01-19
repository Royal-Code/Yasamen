using RoyalCode.OperationResult;
using RoyalCode.Yasamen.Forms.Validation;

namespace RoyalCode.Yasamen.Demos.Forms;

public class Friend
{
    public string? Name { get; set; }

    public string? EMail { get; set; }

    public string? Phone { get; set; }

    public bool IsActive { get; set; } = true;
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
            .WithError("This not a fine phone number", nameof(Friend.Phone));
    }
}