using Godot;
using System;

public class IventoryContainer : TextureRect
{
	private HBoxContainer hboxContainer;
	private Panel SlotScene;
	private Texture tempItemTexture = null;
	private Node currentSlot = null;
	private Node nextSlot = null;
	
	public bool uiOpen = false;
	
	public void _on_BackpackBtn_pressed()
	{
		Visible = !Visible;
		
	}

}
