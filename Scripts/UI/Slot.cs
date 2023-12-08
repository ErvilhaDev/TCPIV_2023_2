using Godot;
using System;

public class Slot : Panel
{
	private TextureRect item;
	Collectable itemNode;
	String itemName;
	bool mouseOn = false;
	bool clicked = false;
	
	[Export] NodePath inventoryManagerPath;
	InventoryManager inventoryManager;

	public override void _Ready()
	{
		item = GetNode<TextureRect>("Item");
		
		inventoryManagerPath = "../../../../../../InventoryManager";
		inventoryManager = GetNode(inventoryManagerPath) as  InventoryManager;
	}
	
	public override void _Process(float delta)
	{
		if(clicked)
		{
			GD.Print( "Clicou em:" + this.GetName() );
			if(itemNode != null)
			{
				inventoryManager.setSelected(itemNode.getName());
			}
		}
		clicked = false;
	}
	
	public override void _Notification(int what)
	{
		switch(what)
		{
			case NotificationMouseEnter:
				this.mouseOn = true;
				break;
			
			case NotificationMouseExit:
				this.mouseOn = false;
				break;
		}
	}
	
	public override void _Input(InputEvent @event)
	{
		if ( @event.IsActionPressed("click") && mouseOn)
		{
			this.clicked = true;
		}
	}

	public void PickFromSlot()
	{
		item.Texture = null;
	}

	public void PutInSlot(Texture newTexture, Collectable _itemNode)
	{
		item.Texture = newTexture;
		this.itemNode = _itemNode;
	}
	
}
