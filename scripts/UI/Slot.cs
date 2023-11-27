using Godot;
using System;

public class Slot : Panel
{
    private TextureRect item;

    public override void _Ready()
    {
        item = GetNode<TextureRect>("Item");
    }

    public void PickFromSlot()
    {
        item.Texture = null;
    }

    public void PutInSlot(Texture newTexture)
    {
        item.Texture = newTexture;
    }
}
