using Godot;
using System;

namespace ClematisTrail.Objects.Characters.Scripts;

public partial class InteractableTest : StaticBody2D
{
	[Export]
	private Resource dialogue;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
