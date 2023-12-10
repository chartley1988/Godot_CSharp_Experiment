 using Godot;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

public partial class Gun : Node2D
{
	[Export(PropertyHint.Range, "1,20")]
	int frequency = 1;
	bool _cooldown = false;
	
	PackedScene bullet;
	CharacterBody2D player;
	Node2D main;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bullet = (PackedScene)GD.Load("scenes/Bullet.tscn");
		player = (CharacterBody2D)GetOwner<CharacterBody2D>();
		main = (Node2D)player.GetParent();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public  async void FireGun()
	{
		if(_cooldown == false)
		{
			_cooldown = true;
			var bullet_instance = (Node2D)bullet.Instantiate();
			bullet_instance.GlobalPosition = new Vector2(GlobalPosition.X, GlobalPosition.Y - 40);
			main.AddChild(bullet_instance);
			await Task.Delay(300/frequency);
			_cooldown = false;
		}


	}

}
