using Godot;

namespace ClematisTrail.Globals;

public partial class DialogicSharp(Node target) : Node
{
	private Node target = target;

	public void Start(string var)
	{
		if (target == null) return;

		target.Call("start", var);
	}
}
