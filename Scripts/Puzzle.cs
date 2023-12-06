using Godot;
using System;
using System.Collections.Generic;

public enum PUZZLE_STATE
	{
		INCOMPLETED,
		COMPLETED
	};
	

[Tool]
public class Puzzle : StaticBody2D
{
	[Export] NodePath inventoryManagerPath;
	InventoryManager inventoryManager;
	
	[Export] List<NodePath> wantedItemPaths;
	List<Collectable> wantedItens;
	[Export] int puzzleSteps;
	
	[Export] NodePath rewardNodePath;
	Reward rewardNode;
	
	PUZZLE_STATE puzzleState;
	bool isComplete;
	
	public override void _Ready()
	{
		inventoryManagerPath = "../../InventoryManager";
		inventoryManager = GetNode(inventoryManagerPath) as InventoryManager;
		
		wantedItens = new List<Collectable>();
		
		foreach(NodePath wantedItemPath in wantedItemPaths)
		{
			wantedItens.Add(GetNode( wantedItemPaths[wantedItemPaths.IndexOf(wantedItemPath)] ) as Collectable);
		}
		
		this.puzzleSteps = wantedItens.Count;
		this.rewardNode = GetNode(rewardNodePath) as Reward;
		
		this.puzzleState = PUZZLE_STATE.INCOMPLETED;
		this.isComplete = false;
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		//Verifies in wich state the puzzle is and do the behaviour of that state
		UpdateState();
		
		//Checks if puzzleSteps is already 0 to change the state to Completed
		ChangeState(puzzleSteps);
	}
	
	private void _on_ClickArea_input_event(object viewport, InputEvent @event, int shape_idx)
	{
		// Where it's gonna check if the item is right and update the steps of puzzle
		if ( @event.IsActionPressed("click"))
		{
			ClickCheck();
		}
		
	}
	
	//What must be done in each state
	private void UpdateState()
	{
		switch (this.puzzleState)
		{
			case PUZZLE_STATE.INCOMPLETED:
				isComplete = false;
				break;
			
			case PUZZLE_STATE.COMPLETED:
				isComplete = true;
				rewardNode.SetReward(true);
				
				break;
				
		}
	}
	
	//Where we actually make the transition between states
	private void ChangeState(int _puzzleSteps)
	{
		if(_puzzleSteps == 0 && puzzleState != PUZZLE_STATE.COMPLETED)
		{
			this.puzzleState = PUZZLE_STATE.COMPLETED;
			GD.Print(this.GetName() + ": está no Estado: COMPLETED");
		}
		
	}
	
	private void ClickCheck()
	{
		String lastFound = "none";
		foreach(Collectable wantedItem in wantedItens)
		{
			int index = wantedItens.IndexOf(wantedItem);
			
			if( wantedItens[index].getName() == inventoryManager.getSelected() &&
			wantedItens[index].getName() != lastFound && puzzleState != PUZZLE_STATE.COMPLETED)
			{
				lastFound = wantedItens[index].getName();
				
				inventoryManager.setSelected("none");
				inventoryManager.removeItem(inventoryManager.itens[inventoryManager.getSelectedId()] );
				
				puzzleSteps -= 1;
				GD.Print("puzzleSteps faltando: " + puzzleSteps);
			}
		}
		
		//jeito para funcionar por odem de itens pedidos:
		// no if e fora do for: wantedItens[(wantedItens.Count - 1) - (puzzleStep - 1)] 	
	}
	
}
