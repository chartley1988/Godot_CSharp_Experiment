using Godot;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

public partial class Spawner : Node2D
{
	PackedScene meteor;
	Node2D main;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		meteor = (PackedScene)GD.Load("scenes/Meteor.tscn");
		main = (Node2D)GetParent();
		SpawnMeteors();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void  _Process(double delta)
	{
	}

	public async void SpawnMeteors()
	{
		var rng = new RandomNumberGenerator();
		for (int i = 0; i < 60; i++)
		{
			var newMeteor = (CharacterBody2D)meteor.Instantiate();
			var randomX = rng.RandfRange(20, GetViewportRect().Size.X - 20);
			newMeteor.GlobalPosition = new Vector2(randomX , -50);
			main.AddChild(newMeteor);
			await Task.Delay(300);
		}

	}
}
