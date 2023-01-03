
using RoyalCode.Yasamen.Components;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class PrimaryFieldButton : FieldButton
{
	public PrimaryFieldButton()
	{
		Style = ButtonStyles.Primary;
	}
}

public sealed class SecondaryFieldButton : FieldButton
{
    public SecondaryFieldButton()
    {
        Style = ButtonStyles.Secondary;
    }
}

public sealed class SuccessFieldButton : FieldButton
{
    public SuccessFieldButton()
    {
        Style = ButtonStyles.Success;
    }
}

public sealed class DangerFieldButton : FieldButton
{
    public DangerFieldButton()
    {
        Style = ButtonStyles.Danger;
    }
}

public sealed class WarningFieldButton : FieldButton
{
    public WarningFieldButton()
    {
        Style = ButtonStyles.Warning;
    }
}

public sealed class InfoFieldButton : FieldButton
{
    public InfoFieldButton()
    {
        Style = ButtonStyles.Info;
    }
}

public sealed class LightFieldButton : FieldButton
{
    public LightFieldButton()
    {
        Style = ButtonStyles.Light;
    }
}

public sealed class DarkFieldButton : FieldButton
{
    public DarkFieldButton()
    {
        Style = ButtonStyles.Dark;
    }
}

public sealed class LinkFieldButton : FieldButton
{
    public LinkFieldButton()
    {
        Style = ButtonStyles.Link;
    }
}