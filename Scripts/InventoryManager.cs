using Godot;
using System;
using System.Collections.Generic;

[Tool]
public class InventoryManager : Node
{
	List<Collectable> itens;
	[Export] NodePath inventoryPath;
	InventoryVars inventory;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		itens = new List<Collectable>();
		
		inventory = GetNode(inventoryPath) as InventoryVars;
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		
	}
	
	public void addItem(Collectable item)
	{
		this.itens.Add(item);
		
		int id;
		id = itens.IndexOf(item);
		int size = itens.Count;
		
		GD.Print("Item Adicionado: " + item.getName() + "id: " + id + " Tamanho da Lista: " + size );
		
		//adicionando imagem no Inventory Container
		inventory.getItemSlot(id).PutInSlot(item.resource.itemImage);
	}
	
	public void removeItem(Collectable item)
	{
		int id = itens.IndexOf(item);
		int size = itens.Count;
		
		if (id != -1) // Verifica se o item está na lista
		{
			// Atualizando os slots após o item removido
			for (int i = id; i < size - 1; i++)	
			{
				Collectable nextItem = itens[i + 1]; // Obter o próximo item na lista
				inventory.getItemSlot(i).PutInSlot(nextItem.resource.itemImage);
			}
			// Limpando o último slot
			inventory.getItemSlot(size - 1).PickFromSlot();
			
			this.itens.Remove(item);
			size = itens.Count;
			
			GD.Print("Item Removido: " + item.getName() + "id: " + id + " Tamanho da Lista: " + size);
		}
	}

}
