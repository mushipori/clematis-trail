using System.Diagnostics;
using System.Runtime.CompilerServices;
using ClematisTrail.GlobalScripts;
using Godot;

namespace ClematisTrail.Objects.Characters;

/// <summary>
/// Controls player movement.
/// Movement is in a grid and is 4-directional.
/// </summary>
public partial class PlayerMovement : Node2D
{
	[Export]
	private AnimationTree animationTree;
	[Export]
	private RayCast2D rayCast;

	private readonly float runScale = 2;
	private readonly float walkScale = 1;
	private bool isMoving = false;
	private Vector2 currDirection = Vector2.Down;
	private CharacterBody2D player;

	public override void _Ready()
	{
		player = GetOwner() as CharacterBody2D;
		animationTree.Active = true;
	}

	public override void _EnterTree()
	{
		InputEvents.OnPlayerMove += Move;
	}

	public override void _ExitTree()
	{
		InputEvents.OnPlayerMove -= Move;
	}

	/// <summary>
	/// InputManager detecs movement input and will fire this function.
	/// Controls the player's movement and movement animations.
	/// </summary>
	/// <param name="direction">Direction the player will face</param>
	private void Move(Vector2 direction)
	{
		currDirection = direction;

		rayCast.Rotation = currDirection.Angle();
		rayCast.ForceRaycastUpdate();

		if (Input.IsActionPressed("run")) animationTree.Set("parameters/TimeScale/scale", runScale);
		else animationTree.Set("parameters/TimeScale/scale", walkScale);

		if (!isMoving)
		{
			isMoving = true;
			animationTree.Set("parameters/PlayerStates/Move/blend_position", currDirection);

			if (rayCast.IsColliding())
			{
				MoveStop();
			}
			else
			{
				Vector2 targetPosition = player.Position + (currDirection * Constants.TILE_SIZE);
				Tween tween = CreateTween();
				tween.TweenProperty(player, "position", targetPosition, .25 / (int)animationTree.Get("parameters/TimeScale/scale"));
				tween.TweenCallback(Callable.From(MoveStop));
			}
		}
	}

	private void MoveStop()
	{
		isMoving = false;
		animationTree.Set("parameters/PlayerStates/Idle/blend_position", currDirection);
	}
}

