using Godot;
using System;

public class PlayerControllerPedro : KinematicBody2D
{
	[Export] public int speed = 3;
	public Vector2 target;
	public Vector2 motion = new Vector2();
	
	[Export] NodePath inventoryPath;
	InventoryVars inventory;

	public override void _Ready()
	{
		inventory = GetNode(inventoryPath) as InventoryVars;
		target = Position;
	}

	public override void _Input(InputEvent @event)
	{
		if ( @event.IsActionPressed("click"))
		{
			target = GetGlobalMousePosition();
			
			GD.Print("Movendo para..." + target);
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		if(!inventory.uiClicked)
		{
			Move();
		}
		
		if(inventory.uiClicked)
		{
			target = Position;
		}
	}
	
	public override void _Process(float delta)
	{
		
	}
	
	private void Move()
	{
		motion = Position.DirectionTo(target) * speed * 100;
		// LookAt(target);
		if (Position.DistanceTo(target) > 5)
		{
			motion = MoveAndSlide(motion);
		}
	}
}
