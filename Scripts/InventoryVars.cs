using Godot;
using System;

public class InventoryVars : Node2D
{
	[Export] NodePath buttonPath;
	BackpackBtn button;
	
	public bool uiClicked;
	
	public override void _Ready()
	{
		button = GetNode(buttonPath) as BackpackBtn;
		uiClicked = button.uiClicked;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame
	public override void _Process(float delta)
  	{
		uiClicked = button.uiClicked;
  	}
	
}
