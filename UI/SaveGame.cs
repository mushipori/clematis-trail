using ClematisTrail.Globals;
using Godot;

namespace ClematisTrail.UI;

public partial class SaveGame : TextureButton
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
