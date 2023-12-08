using Godot;
using System;

public class ChangeScene : CollisionShape2D
{
	[Export] string stageName;
	[Export] string sceneName;
	
	public override void _Ready()
	{
		
	}
	
	private void _on_SceneChangeArea_body_entered(object body)
	{
		if( !(body is PlayerControllerPedro) )
			return;
		else
			LoadScene(sceneName, stageName);
	}

	private void LoadScene(string _sceneName, string _stageName)
	{
		GetTree().ChangeScene("res://Stages/" + stageName + "/" + _sceneName + ".tscn");
	}
	
}
