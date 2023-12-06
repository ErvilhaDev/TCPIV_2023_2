using Godot;
using System;
using System.Collections.Generic;

[Tool]
public class PuzzleNodeScript : StaticBody2D
{
	private const string ScenePath = "res://addons/folklorePlugin/pluginScenes/Puzzle.tscn";
	PackedScene puzzleScene = (PackedScene)ResourceLoader.Load(ScenePath);
		
	public override void _EnterTree()
	{
		if (Engine.IsEditorHint())
		{
			Node _puzzleScene = puzzleScene.Instance();
			GetParent().AddChild(_puzzleScene);
			_puzzleScene.SetOwner(GetTree().GetEditedSceneRoot());
			QueueFree();
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

}
