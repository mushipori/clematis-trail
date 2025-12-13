using ClematisTrail.GlobalScripts;
using Godot;
using System.Linq;

namespace ClematisTrail.Objects.UI;

/// <summary>
/// Manages input for switching between menu tabs
/// </summary>
public partial class TabManager : Node
{
	[Export]
	private TextureButton activeTab;

	private TextureButton prevActiveTab;

	public override void _Ready()
	{
		FocusTab(activeTab);
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed(Constants.UI_RIGHT_INPUT))
		{
			FocusTab(GetNode<TextureButton>(activeTab.FocusNeighborRight));
		}
		else if (Input.IsActionJustPressed(Constants.UI_LEFT_INPUT))
		{
			FocusTab(GetNode<TextureButton>(activeTab.FocusNeighborLeft));
		}
	}

	/// <summary>
	/// Switch with menu tab is focused
	/// </summary>
	/// 
	/// <param name="nextTab">Tab to switch to</param>
	private void FocusTab(TextureButton nextTab)
	{
		prevActiveTab = activeTab;
		activeTab = nextTab;
		activeTab.CallDeferred("grab_focus");

		foreach (var page in prevActiveTab.GetChildren().OfType<TextureRect>())
		{
			page.Hide();
		}

		foreach (var page in activeTab.GetChildren().OfType<TextureRect>())
		{
			page.Show();
		}
	}
}
