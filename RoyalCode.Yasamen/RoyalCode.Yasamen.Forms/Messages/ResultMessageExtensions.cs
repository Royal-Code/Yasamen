
using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms.Messages;

public static class ResultMessageExtensions
{
    public static ResultMessageType GetMessageType(this IResultMessage message)
    {
        if ((message.AdditionalInformation?.TryGetValue("type", out var type) ?? false)
            && (type is int typeValue))
        {
            return (ResultMessageType)typeValue;
        }
        return ResultMessageType.Error;
    }
}

