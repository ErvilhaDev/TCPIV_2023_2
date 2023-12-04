using Godot;
using System.Collections.Generic;

public enum STATE { IDLE, MOVING, INTERACT }

public class Control : Node2D
{
    Player2 Player = new Player2();
    Line2D line = new Line2D();
    Navigation2D nav2D = new Navigation2D();
    Area2D interactions = new Area2D();
	BackpackBtn Backpack = new BackpackBtn();

    public override void _Ready()
    {
        nav2D = GetNode<Navigation2D>("Navigation2D");
        line = GetNode<Line2D>("Line2D");
        Player = GetNode<Player2>("Player2");
        interactions = GetNode<Area2D>("Interactions");
    }

    public override void _Input(InputEvent @event)
    {

        if (@event.IsActionPressed("click"))
        {
            Vector2[] newPath = nav2D.GetSimplePath(Player.GetGlobalPosition(),
            GetGlobalMousePosition());
            //GD.Print("New Path: ", newPath);
            line.Points = newPath;
            Player.Path = new List<Vector2>(newPath);

            Player.currentState = Player2.STATE.MOVING;
            Player.isInteracting = false;
        }

    }

    private void _on_Interactions_input_event(object viewport, InputEvent @event, int shape_idx)
    {
        if (@event.IsActionPressed("click")){
            Player.isInteracting = true;
			Player.interactObject = interactions.GetChild(shape_idx);
			GD.Print("Interacting");
        }
    }
}
