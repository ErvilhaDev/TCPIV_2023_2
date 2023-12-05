using Godot;
using System;
using System.Collections.Generic;


public class InventoryVars : Node2D
{
	[Export] NodePath buttonPath;
	BackpackBtn button;
	
	[Export] List<NodePath> itemSlotPaths;
	List<Slot> itemSlot;
	
	
	public bool uiClicked;
	
	public override void _Ready()
	{
		itemSlot = new List<Slot>();
		
		button = GetNode(buttonPath) as BackpackBtn;
		uiClicked = button.uiClicked;
		
		foreach(NodePath itemSlotPath in itemSlotPaths)
		{
			itemSlot.Add(GetNode(itemSlotPaths[itemSlotPaths.IndexOf(itemSlotPath)]) as Slot);
		}
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame
	public override void _Process(float delta)
  	{
		uiClicked = button.uiClicked;
  	}
	
	public Slot getItemSlot(int index)
	{
		return itemSlot[index];
	}
	
}
