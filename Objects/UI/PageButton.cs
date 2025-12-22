using Godot;

namespace ClematisTrail.Objects.UI;

/// <summary>
/// Template script to handle event when button is pressed. To edit this script, make the script unique in the Godot editor then edit the script here
/// </summary>
public partial class PageButton : TextureButton
{
	public override void _EnterTree()
	{
		Pressed += OnButtonPressed;
	}

	public override void _ExitTree()
	{
		Pressed -= OnButtonPressed;
	}

	private void OnButtonPressed()
	{

	}
}
