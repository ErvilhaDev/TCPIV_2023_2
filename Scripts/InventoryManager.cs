using Godot;
using System;
using System.Collections.Generic;

[Tool]
public class InventoryManager : Node
{
	List<Collectable> itens;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		itens = new List<Collectable>();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		
	}
	
	public void addItem(Collectable item)
	{
		this.itens.Add(item);
		GD.Print("Item Adicionado: " + item.getName() + " Tamanho da Lista: " + ((itens.Count) -1));
	}
}
