using Godot;
using System;

public class Reward : Node
{
	bool reward;
	bool rewardGiven;
	
	public override void _Ready()
	{
		this.reward = false;
		this.rewardGiven = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Reaction();
	}
	
	public virtual void SetReward(bool _bool)
	{
		this.reward = _bool;
	}
	
	public void Reaction()
	{
		if(reward && !rewardGiven)
		{
			GD.Print("Recompensa Liberada em: " + this.GetName() );
			rewardGiven = true;
		}
	}
	
}
