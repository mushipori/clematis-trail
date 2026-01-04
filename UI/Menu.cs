using System.Diagnostics;
using System.Linq;
using ClematisTrail.Globals;
using Godot;

namespace ClematisTrail.UI;

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
	private bool isPageSelected = false; // When true, user can select page items and cancelling will return to tab

	public override void _Ready()
	{
		// Hide all pages
		foreach (var page in pageGroup.GetChildren().OfType<TextureRect>())
		{
			page.Hide();
		}

		menu.Hide();
	}

	public override void _EnterTree()
	{
		InputEvents.OnToggleMenu += ToggleMenu;
		InputEvents.OnEnablePageControl += EnablePageControl;
		InputEvents.OnDisablePageControl += DisablePageControl;
		InputEvents.OnUpdateActiveTab += UpdateActiveTab;
		InputEvents.OnCancel += Cancel;
	}

	public override void _ExitTree()
	{
		InputEvents.OnToggleMenu -= ToggleMenu;
		InputEvents.OnEnablePageControl -= EnablePageControl;
		InputEvents.OnDisablePageControl -= DisablePageControl;
		InputEvents.OnUpdateActiveTab -= UpdateActiveTab;
		InputEvents.OnCancel -= Cancel;
	}

	private void ToggleMenu()
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

	private void EnablePageControl()
	{
		isPageSelected = true;
	}

	private void DisablePageControl()
	{
		isPageSelected = false;
	}

	private void UpdateActiveTab(TextureButton tab)
	{
		activeTab = tab;
	}

	private void Cancel()
	{
		if (isPageSelected)
		{
			activeTab.CallDeferred("grab_focus");
			InputEvents.RaiseDisablePageControl();
		}
	}
}
