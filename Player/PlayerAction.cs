using Godot;

namespace ClematisTrail.Player;

public partial class PlayerAction : Node
{
	[Export]
	private RayCast2D rayCast;
	private bool canInteract = false;

	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (rayCast.IsColliding())
		{
			var collider = rayCast.GetCollider();
		}
	}
}
