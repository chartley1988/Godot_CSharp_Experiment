using Godot;
using System;

public partial class Bullet : CharacterBody2D
{
	[Export(PropertyHint.File,"AudioStream")]
	AudioStream sound_effect;

	[Export(PropertyHint.Range, "0.1, 0.9")]
	float pitch;

	[Export(PropertyHint.Range, "0.1, 0.9")]
	float variance;

	int speed = 500;
	private Vector2 Window;
	PackedScene soundScene;
	public Node2D main;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Window = GetViewportRect().Size;
		soundScene = (PackedScene)GD.Load("scenes/SoundEffect.tscn");
		PlaySound();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Velocity = new Vector2(0, -speed);
		MoveAndSlide();
		CheckBoundary();
	}

	private void CheckBoundary()
	{
		if(GlobalPosition.Y < -50 || GlobalPosition.Y > Window.Y + 50)
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
		sound.variance = true;
		sound.variance_amount = variance;
		main.AddChild(sound);
		sound.PlaySound();
		
	}
}
