using ClematisTrail.GlobalScripts;
using Godot;

namespace ClematisTrail.Objects.UI;

/// <summary>
/// Manages raising inputs related to toggling the menu
/// </summary>
public partial class MenuManager : Node
{
	[Export]
	Control menu;
	Color defaultColor;

	public override void _Ready()
	{
		if (menu != null) defaultColor = menu.Modulate;
		HideMenu();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed(Constants.MENU_TOGGLE))
		{
			if (menu.Modulate.A > 0)
			{
				InputEvents.RaiseContextSwitch(Constants.InputContexts.Game);
				HideMenu();
			}
			else
			{
				InputEvents.RaiseContextSwitch(Constants.InputContexts.Menu);
				ShowMenu();
			}
		}
	}

	private void ShowMenu()
	{
		menu.Modulate = new Color(defaultColor.R, defaultColor.G, defaultColor.B, 1.0f);
	}

	private void HideMenu()
	{
		menu.Modulate = new Color(defaultColor.R, defaultColor.G, defaultColor.B, 0f);
	}
}
