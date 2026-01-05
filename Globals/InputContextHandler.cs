using Godot;

namespace ClematisTrail.Globals;

/// <summary>
/// Handles context switch event
/// </summary>
public partial class InputContextHandler : Node
{
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
	}

	public override void _EnterTree()
	{
		InputEvents.OnContextSwitch += SwitchInputContext;
	}

	public override void _ExitTree()
	{
		InputEvents.OnContextSwitch -= SwitchInputContext;
	}

	private void SwitchInputContext(Constants.InputContexts context)
	{
		// Script needs to be attached to an object so that it can pause the tree
		if (context == Constants.InputContexts.Game)
		{
			GetTree().Paused = false;
			InputEvents.RaiseEnablePlayerMove();
		}
		else if (context == Constants.InputContexts.Menu)
		{
			GetTree().Paused = true;
			InputEvents.RaiseDisablePlayerMove();
		}
	}
}