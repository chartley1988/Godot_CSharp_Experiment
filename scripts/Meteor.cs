using Godot;
using System;
using System.Runtime;

public partial class Meteor : CharacterBody2D
{
	[Export(PropertyHint.File,"AudioStream")]
	AudioStream sound_effect;

	[Export(PropertyHint.Range, "0.1, 0.9")]
	float pitch;

	[Export(PropertyHint.Range, "0.1, 0.9")]
	float variance;

	public float rotate_speed = 100;
	public float speed = 10000;

	private Node2D main;
	private Vector2 Window;
	PackedScene soundScene;

    public override void _Ready()
    {
        main = (Node2D)GetParent();
		Window = GetViewportRect().Size;
		soundScene = (PackedScene)GD.Load("scenes/SoundEffect.tscn");
    }

    public override void _PhysicsProcess(double delta)
	{
		RotationDegrees += rotate_speed * (float)delta;
		Velocity = new Vector2(0, speed * (float)delta);
		var collision = MoveAndCollide(Velocity * (float)delta);
		if(collision != null) {
			var target = collision.GetCollider();
			var player = GetTree().GetFirstNodeInGroup("Player");
			if(player == target)
			{
			main.EmitSignal("GameOver");
			PlaySound();
			QueueFree();
			}
			else
			{
				PlaySound();
				if(target.GetType().ToString() == "Bullet")
				{
					var bullet = (CharacterBody2D)target;
					bullet.QueueFree();
				}
				QueueFree();
				
			}
		}

		CheckBoundary();


	}

	private void CheckBoundary()
	{
		if(GlobalPosition.Y > Window.Y + 50)
		{
			QueueFree();
			return;
		}
	}

	private void PlaySound() 
	{
		if(sound_effect == null)
		{
			return;
		}
		SoundEffect sound = (SoundEffect)soundScene.Instantiate();
		sound.Stream = sound_effect;
		sound.PitchScale = pitch;
		sound.variance = true;
		sound.variance_amount = variance;
		main.AddChild(sound);
		sound.PlaySound();
		
	}
}
