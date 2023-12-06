#if TOOLS
using Godot;
using System;

[Tool]
public class folklorePlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.
		// Add the new type with a name, a parent type, a script and an icon.
		var script = GD.Load<Script>("res://addons/folklorePlugin/pluginScripts/PuzzleNodeScript.cs");
		var texture = GD.Load<Texture>("res://addons/folklorePlugin/puzzleIcon.png");
		AddCustomType("PuzzleNode", "StaticBody2D", script, texture);
	}

	public override void _ExitTree()
	{
		RemoveCustomType("Puzzle");
	}
	
}
#endif
