class_name DefaultItem
extends Node2D

var collected: bool = false

func _on_Area2D_body_entered(body):
	if body.name == "Player":
		collected = true
		print("Colected")
