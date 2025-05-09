
namespace RoyalCode.Yasamen.Components;

public sealed class PrimaryButton : Button
{
	public PrimaryButton()
	{
		Style = ButtonStyles.Primary;
	}
}

public sealed class SecondaryButton : Button
{
    public SecondaryButton()
    {
        Style = ButtonStyles.Secondary;
    }
}

public sealed class SuccessButton : Button
{
    public SuccessButton()
    {
        Style = ButtonStyles.Success;
    }
}

public sealed class DangerButton : Button
{
    public DangerButton()
    {
        Style = ButtonStyles.Danger;
    }
}

public sealed class WarningButton : Button
{
    public WarningButton()
    {
        Style = ButtonStyles.Warning;
    }
}

public sealed class InfoButton : Button
{
    public InfoButton()
    {
        Style = ButtonStyles.Info;
    }
}

public sealed class LightButton : Button
{
    public LightButton()
    {
        Style = ButtonStyles.Light;
    }
}

public sealed class DarkButton : Button
{
    public DarkButton()
    {
        Style = ButtonStyles.Dark;
    }
}

public sealed class LinkButton : Button
{
    public LinkButton()
    {
        Style = ButtonStyles.Link;
    }
}