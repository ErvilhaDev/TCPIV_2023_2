using Godot;
using System;

public class BackpackBtn : Button
{
    private Texture openTexture = (Texture)GD.Load("res://assets/Inventory/backpack_open.png");
    private Texture closedTexture = (Texture)GD.Load("res://assets/Inventory/backpack.png");
	
	public bool uiClicked = false;

    public override void _Process(float delta)
    {
        if (Pressed)
        {
			uiClicked = true;
            SetButtonIcon(openTexture);
        }
        else
        {
			uiClicked = false;
            SetButtonIcon(closedTexture);
        }
    }
}
