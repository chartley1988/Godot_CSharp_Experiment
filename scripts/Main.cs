using Godot;
using System;

public partial class Main : Node2D
{
	[Signal]
	public delegate void GameOverEventHandler();

	CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameOver += () => EndGame();
		player = (CharacterBody2D)GetNode("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void EndGame() {
		GD.Print("Game Over!");
		player.QueueFree();
	}
}
