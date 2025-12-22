using Godot;
using System;

namespace ClematisTrail.GlobalScripts;

/// <summary>
/// Declarations for input events
/// </summary>
public static class InputEvents
{
	public static event Action<Constants.InputContexts> OnContextSwitch;
	public static event Action OnEnablePageControl;
	public static event Action OnDisablePageControl;
	public static event Action<TextureButton> OnUpdateActiveTab;
	public static event Action<Vector2> OnPlayerMove;
	public static event Action OnDisablePlayerMove;
	public static event Action OnEnablePlayerMove;

	// Switch between game paused state for menu controls and game unpaused state for game controls
	public static void RaiseContextSwitch(Constants.InputContexts context)
	{
		OnContextSwitch?.Invoke(context);
	}

	public static void RaiseEnablePageControl()
	{
		OnEnablePageControl?.Invoke();
	}

	public static void RaiseDisablePageControl()
	{
		OnDisablePageControl?.Invoke();
	}

	public static void RaiseUpdateActiveTab(TextureButton tab)
	{
		OnUpdateActiveTab?.Invoke(tab);
	}

	// Handle player movement input
	public static void RaisePlayerMove(Vector2 direction)
	{
		OnPlayerMove?.Invoke(direction);
	}

	// Disable player movement when menu is open
	public static void RaiseDisablePlayerMove()
	{
		OnDisablePlayerMove?.Invoke();
	}

	// Enable player movement when menu is closed
	public static void RaiseEnablePlayerMove()
	{
		OnEnablePlayerMove?.Invoke();
	}
}
