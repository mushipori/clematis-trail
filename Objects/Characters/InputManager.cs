using System.Collections.Generic;
using System.Diagnostics;
using ClematisTrail.GlobalScripts;
using Godot;

namespace ClematisTrail.Objects.Characters;

/// <summary>
/// Manages raising events related to player input
/// </summary>
public partial class InputManager : Node
{
	private Vector2 direction = Vector2.Zero;
	private readonly List<Vector2> inputQueue = [];

	public override void _PhysicsProcess(double delta)
	{
		// If just pressed, push input to beginning of queue
		if (Input.IsActionJustPressed(Constants.UP_INPUT))
		{
			if (!inputQueue.Contains(Vector2.Up)) inputQueue.Insert(0, Vector2.Up);
		}
		else if (Input.IsActionJustPressed(Constants.DOWN_INPUT))
		{
			if (!inputQueue.Contains(Vector2.Down)) inputQueue.Insert(0, Vector2.Down);
		}
		else if (Input.IsActionJustPressed(Constants.LEFT_INPUT))
		{
			if (!inputQueue.Contains(Vector2.Left)) inputQueue.Insert(0, Vector2.Left);
		}
		else if (Input.IsActionJustPressed(Constants.RIGHT_INPUT))
		{
			if (!inputQueue.Contains(Vector2.Right)) inputQueue.Insert(0, Vector2.Right);
		}

		// If just released an input, remove input from queue
		if (Input.IsActionJustReleased(Constants.UP_INPUT))
		{
			inputQueue.Remove(Vector2.Up);
		}
		else if (Input.IsActionJustReleased(Constants.DOWN_INPUT))
		{
			inputQueue.Remove(Vector2.Down);
		}
		else if (Input.IsActionJustReleased(Constants.LEFT_INPUT))
		{
			inputQueue.Remove(Vector2.Left);
		}
		else if (Input.IsActionJustReleased(Constants.RIGHT_INPUT))
		{
			inputQueue.Remove(Vector2.Right);
		}

		if (Input.IsActionPressed(Constants.MOVE_INPUT) || Input.IsActionJustReleased(Constants.MOVE_INPUT))
		{
			if (inputQueue.Count != 0)
			{
				direction = inputQueue[0];
			}
			InputEvents.RaisePlayerMove(direction);
		}
	}
}