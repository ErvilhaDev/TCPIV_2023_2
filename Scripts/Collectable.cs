using Godot;
using System;

[Tool] 
public class Collectable : Node2D
{
	[Export] public CollectableData resource;
	Area2D clickableArea;
	InventoryManager inventoryManager;
	Sprite itemSprite;
	String itemName;
	
	[Export] NodePath itemSpritePath;
	[Export] NodePath inventoryManagerPath;
	[Export] NodePath clickableAreaPath;
	
	public override void _Ready()
	{
		//assigning Nodes
		itemSprite = GetNode(itemSpritePath) as Sprite;
		
		inventoryManagerPath = "../../../InventoryManager";
		inventoryManager = GetNode(inventoryManagerPath) as InventoryManager;
		//InventoryManager inventoryManager = (InventoryManager)GetNode("/root/InventoryManager");
		
		clickableArea = GetNode(clickableAreaPath) as Area2D;
		
		
		//assigning Resource Data
		itemSprite.Texture = resource.itemImage;
		this.itemName = resource.itemName;
		
	}
	
	//With Build in Signal
	//Collectable clicked Signal
	private void _on_DetectableArea_input_event(object viewport, InputEvent @event, int shape_idx)
	{
		if(@event.IsActionPressed("click"))
		{
			GD.Print("Clicado... Aguarde o Personagem colidir com o Item");
		}
		
	}
	
	//Collectable hovered Signal
	private void _on_DetectableArea_mouse_entered()
	{
		GD.Print("Mouse por cima de coletável");
	}
	
	//Collectable collision Signal
	private void _on_DetectableArea_body_entered(Node body)
	{	
		if(!(body is PlayerControllerPedro))
			return;
		else
			picked();
	}
	
	
	private void picked()
	{
		CallDeferred("free");
		inventoryManager.addItem(this);
	}
	
	public string getName()
	{
		return itemName;
	}
}
