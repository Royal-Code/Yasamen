namespace RoyalCode.Yasamen.Commons;

public sealed class AdditionalAttributes
{
    private IEnumerable<KeyValuePair<string, object>>? capturedAttributes;
    private Dictionary<string, CapturedValue>? capturedValues;

    public void CapturedUnmatchedAttributes(IEnumerable<KeyValuePair<string, object>>? unmatchedAttributes)
    {
        capturedAttributes = unmatchedAttributes;

        if (capturedValues is not null && capturedAttributes is not null)
        {
            foreach (var captured in capturedValues.Keys)
            {
                capturedAttributes = capturedAttributes.Where(x => x.Key != captured);
            }
        }
    }

    public IEnumerable<KeyValuePair<string, object>>? GetCapturedAttributes()
    {
        if (capturedAttributes is null)
            return null;

        if (capturedValues is not null)
        {
            var attributes = new Dictionary<string, object>(capturedAttributes);
            foreach (var captured in capturedValues.Keys)
            {
                attributes.Remove(captured);
            }
            return attributes;
        }

        return capturedAttributes is Dictionary<string, object> dictionary
            ? dictionary
            : capturedAttributes.ToDictionary(x => x.Key, x => x.Value);
    }

    public CapturedValue CaptureValue(string attributeName)
    {
        capturedValues ??= [];
        if (capturedValues.TryGetValue(attributeName, out var capturedValue))
            return capturedValue;

        capturedValue = new CapturedValue();
        capturedValues[attributeName] = capturedValue;
        return capturedValue;
    }

    public CapturedValue CaptureClass() => CaptureValue("class");

    public CapturedValue CaptureStyle() => CaptureValue("style");

    public CapturedValue CaptureId() => CaptureValue("id");

    public CapturedValue CaptureName() => CaptureValue("name");

    public CapturedValue CaptureLabel() => CaptureValue("label");
}
