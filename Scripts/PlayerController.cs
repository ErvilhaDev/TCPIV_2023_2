using Godot;
using System;

public class PlayerController : KinematicBody2D
{
    [Export] public int speed = 200; // Player movement speed

    public Vector2 target;
    public Vector2 velocity = new Vector2();

    public bool ismoving = false;

    public override void _Ready()
    {
        target = Position;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("click"))
        {
            target = GetGlobalMousePosition();
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

        velocity = Position.DirectionTo(target) * speed;
        //GD.Print(ismoving);
        if (Position.DistanceTo(target) > 5)
        {
            ismoving = true;
            
            velocity = MoveAndSlide(velocity);
        }
        else{
            ismoving = false;
        }

        if (ismoving == false){
            animatedSprite.Animation = "default";
        }
        if (velocity.x != 0 && ismoving == true){
            animatedSprite.Animation = "MovLeft";
            animatedSprite.FlipH = velocity.x > 0;
        }
        if (velocity.y < 0 && velocity.y < velocity.x && ismoving == true){
            animatedSprite.Animation = "MovUp";
            //animatedSprite.FlipH = velocity.x > 0;
        }
        if (velocity.y > 0 && velocity.y > velocity.x && ismoving == true){
            animatedSprite.Animation = "MovDown";
            //animatedSprite.FlipH = velocity.x > 0;
        }
    }
}
