using Godot;
using System;

public class PlayerControllerPedro : KinematicBody2D
{
	[Export] public int speed = 3;
	
	public Vector2 target;
	public Vector2 motion = new Vector2();

	public override void _Ready()
	{
			target = Position;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("click"))
		{
			target = GetGlobalMousePosition();
			GD.Print("Movendo para..." + target);
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		motion = Position.DirectionTo(target) * speed * 100;
		// LookAt(target);
		if (Position.DistanceTo(target) > 5)
		{
			motion = MoveAndSlide(motion);
		}
	}
	
	public override void _Process(float delta)
	{
		
	}
}
