using Godot;
using System;
using System.Reflection.Metadata;

namespace ClematisTrail.GlobalScripts;

public static class Constants
{
	// Tile size
	public const int TILE_SIZE = 32;

	// Collision Layers


	// Input Maps
	public const string MOVE_INPUT = "move"; // All 4 directions
	public const string UP_INPUT = "move_up";
	public const string DOWN_INPUT = "move_down";
	public const string LEFT_INPUT = "move_left";
	public const string RIGHT_INPUT = "move_right";
}
