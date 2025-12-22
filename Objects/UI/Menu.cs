using System.Linq;
using ClematisTrail.GlobalScripts;
using Godot;

namespace ClematisTrail.Objects.UI;

/// <summary>
/// Handles raising inputs related to toggling the menu and handling tab/page control
/// </summary>
public partial class Menu : Node
{
	[Export]
	private Control menu;
	[Export]
	private Control pageGroup;
	[Export]
	private TextureButton activeTab; // Track last active tab, so the state is kept when menu is closed and reopened
	private bool pageSelected = false; // When true, user can select page items and cancelling will return to tab

	public override void _Ready()
	{
		// Hide all pages
		foreach (var page in pageGroup.GetChildren().OfType<TextureRect>())
		{
			page.Hide();
		}

		menu.Hide();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed(Constants.MENU_TOGGLE_INPUT))
		{
			if (menu.Visible)
			{
				InputEvents.RaiseContextSwitch(Constants.InputContexts.Game);
				InputEvents.RaiseDisablePageControl(); // Return to tab control
				menu.Hide();
			}
			else
			{
				InputEvents.RaiseContextSwitch(Constants.InputContexts.Menu);
				menu.Show();
				activeTab.CallDeferred("grab_focus"); // Last active tab will be focused
			}
		}
		else if (pageSelected)
		{
			// If focus on menu page element and cancel pressed, then return focus to the tab of that page
			if (Input.IsActionJustPressed(Constants.UI_CANCEL_INPUT))
			{
				activeTab.CallDeferred("grab_focus");
				InputEvents.RaiseDisablePageControl();
			}
		}
	}

	public override void _EnterTree()
	{
		InputEvents.OnEnablePageControl += EnablePageControl;
		InputEvents.OnDisablePageControl += DisablePageControl;
		InputEvents.OnUpdateActiveTab += UpdateActiveTab;
	}

	public override void _ExitTree()
	{
		InputEvents.OnEnablePageControl -= EnablePageControl;
		InputEvents.OnDisablePageControl -= DisablePageControl;
		InputEvents.OnUpdateActiveTab -= UpdateActiveTab;
	}

	private void EnablePageControl()
	{
		pageSelected = true;
	}

	private void DisablePageControl()
	{
		pageSelected = false;
	}

	private void UpdateActiveTab(TextureButton tab)
	{
		activeTab = tab;
	}
}
