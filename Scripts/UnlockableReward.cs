using Godot;
using System;

public class UnlockableReward : Reward
{
	bool reward;
	bool rewardGiven;
	
	[Export] NodePath doorCollisionPath;
	CollisionShape2D doorCollision; 
	
	[Export] NodePath changeSceneCollisionPath;
	CollisionShape2D changeSceneCollision; 
	
	[Export] NodePath imagePath;
	Sprite image; 
	
	public override void _Ready()
	{
		this.reward = false;
		this.rewardGiven = false;
		
		doorCollision = GetNode(doorCollisionPath) as CollisionShape2D;
		changeSceneCollision = GetNode(changeSceneCollisionPath) as CollisionShape2D;
		image = GetNode(imagePath) as Sprite;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Reaction();
	}
	
	public override void SetReward(bool _bool)
	{
		this.reward = _bool;
	}
	
	public void Reaction()
	{
		if(reward && !rewardGiven)
		{
			doorCollision.SetDisabled(true);
			changeSceneCollision.SetDisabled(false);
			image.SetVisible(false);
			
			GD.Print("Recompensa Liberada em: " + this.GetName() );
			rewardGiven = true;
		}
	}
	
}
