namespace RoyalCode.Razor.Commons.Results;

/// <summary>
/// Represents a result message with an associated type and text.
/// </summary>
/// <remarks>
/// Use this class to standardize return messages in operations, including success, alert, or error.
/// </remarks>
public class Message
{
    /// <summary>
    /// Default instance representing a successful message.
    /// </summary>
    public static readonly Message Success = new(MessageType.Success);

    /// <summary>
    /// Message type (e.g., Success, Error, Alert).
    /// </summary>
    /// <value>
    /// A value from the <see cref="MessageType"/> enum that classifies the message.
    /// </value>
    public MessageType Type { get; set; }
    
    /// <summary>
    /// Descriptive text of the message.
    /// </summary>
    /// <value>
    /// Text content explaining or detailing the message.
    /// </value>
    public string Text { get; set; }
    
    /// <summary>
    /// Creates a new instance of <see cref="Message"/> with explicit type and text.
    /// </summary>
    /// <param name="type">The type of the message.</param>
    /// <param name="text">The descriptive text of the message.</param>
    public Message(MessageType type, string text)
    {
        Type = type;
        Text = text;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Message"/> using the type name as text.
    /// </summary>
    /// <param name="type">The type of the message.</param>
    /// <remarks>
    /// The text will be filled with <c>type.ToString()</c>.
    /// </remarks>
    public Message(MessageType type)
    {
        Type = type; 
        Text = type.ToString();
    }
}

/// <summary>
/// Enumeration of possible result message types.
/// </summary>
public enum MessageType
{
    /// <summary>
    /// Message indicates success in the operation.
    /// </summary>
    Success,

    /// <summary>
    /// Informative message without error implications.
    /// </summary>
    Info,

    /// <summary>
    /// Highlighted message to draw special attention.
    /// </summary>
    Highlight,

    /// <summary>
    /// Warning message about a potentially problematic condition.
    /// </summary>
    Warning,

    /// <summary>
    /// Alert message about a relevant or critical situation.
    /// </summary>
    Alert,

    /// <summary>
    /// Message indicates failure or error in the operation.
    /// </summary>
    Error,
}