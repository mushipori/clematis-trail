using System.Diagnostics;
using Godot;

namespace ClematisTrail.Globals;

public partial class InputManager : Node
{
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed(Constants.MENU_TOGGLE_INPUT))
		{
			InputEvents.RaiseToggleMenu();
		}

		if (Input.IsActionJustPressed(Constants.UI_CANCEL_INPUT))
		{
			InputEvents.RaiseCancel();
		}
	}
}