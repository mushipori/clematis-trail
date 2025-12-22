using ClematisTrail.GlobalScripts;
using Godot;

namespace ClematisTrail.Objects.UI;

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
