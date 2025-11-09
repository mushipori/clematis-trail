using Godot;
using System;

namespace ClematisTrail.GlobalScripts;

public static class InputEvents
{
	public static event Action<Vector2> OnPlayerMove;

	public static void RaisePlayerMove(Vector2 direction)
	{
		OnPlayerMove?.Invoke(direction);
	}
}
