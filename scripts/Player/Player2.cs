using Godot;
using System.Collections.Generic;

public class Player2 : KinematicBody2D
{
    [Export] public int speed = 300; // Player movement speed
    public List<Vector2> Path = new List<Vector2>();
    Vector2 distance = new Vector2();
    Vector2 destination = new Vector2();

    public bool isInteracting = false;
    public object interactObject = null;

    public enum STATE
    {
        IDLE,
        MOVING,
        INTERACT
    };

    public STATE currentState = STATE.IDLE;

    public override void _Ready()
    {
        destination = Position;
    }

    public override void _PhysicsProcess(float delta)
    {
        switch (currentState)
        {
            case STATE.IDLE:
                break;
            case STATE.MOVING:
                MoveAlongPath(delta);
                break;
            case STATE.INTERACT:
                break;
            default:
                break;
        }
    }

    void MoveAlongPath(float delta)
    {
        if (Path.Count > 0)
        {
            //GD.Print("Moving along path...");
            Vector2 targetPoint = Path[0];
            Vector2 direction = (targetPoint - Position).Normalized();
            Vector2 velocity = direction * speed * delta;

            MoveAndSlide(velocity);

            if (Position.DistanceTo(targetPoint) < 1.0f)
            {
                //GD.Print("Reached target point. Removing from path.");
                // If the player is close enough to the target point, remove it from the path
                Path.RemoveAt(0);
            }

            if (Path.Count == 0)
            {
                if(isInteracting){
					GD.Print("No more points in the path. Changing state to INTERACT.");
                    currentState = STATE.INTERACT;
                }
                else{
                    GD.Print("No more points in the path. Changing state to IDLE.");
                    currentState = STATE.IDLE;
                }
                
            }
        }
    }
}
