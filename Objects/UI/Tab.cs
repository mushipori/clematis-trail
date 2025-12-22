using ClematisTrail.GlobalScripts;
using Godot;

namespace ClematisTrail.Objects.UI;

/// <summary>
/// Handles events for tab focus and page control. Attached to a tab node.
/// 
/// Assign NeighborTop, NeighborBottom, Next, and Previous focus properties to the self tab to prevent unexpected focus switching.
/// </summary>
public partial class Tab : TextureButton
{
	[Export]
	private TextureButton initialPageButton;
	[Export]
	private TextureRect tabPage;
	private bool pageSelected = false;

	public override void _EnterTree()
	{
		FocusEntered += OnFocusEntered;
		FocusExited += OnFocusExited;
		Pressed += OnButtonPressed;
		InputEvents.OnEnablePageControl += EnablePageControl;
		InputEvents.OnDisablePageControl += DisablePageControl;
	}

	public override void _ExitTree()
	{
		FocusEntered -= OnFocusEntered;
		FocusExited -= OnFocusExited;
		Pressed -= OnButtonPressed;
		InputEvents.OnEnablePageControl -= EnablePageControl;
		InputEvents.OnDisablePageControl -= DisablePageControl;
	}

	private void OnFocusEntered()
	{
		InputEvents.RaiseUpdateActiveTab(this);

		tabPage.Show();
	}

	private void OnFocusExited()
	{
		if (!pageSelected)
		{
			tabPage.Hide();
		}
	}

	private void OnButtonPressed()
	{
		if (initialPageButton != null)
		{
			InputEvents.RaiseEnablePageControl(); // Turn on page control
			initialPageButton.CallDeferred("grab_focus");
		}
	}

	private void EnablePageControl()
	{
		pageSelected = true; // Prevent page from being hidden in OnFocusExited
	}

	private void DisablePageControl()
	{
		pageSelected = false; // Tab control should be on. Allow page to be hidden in OnFocusExited
	}
}
