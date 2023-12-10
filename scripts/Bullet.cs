using Godot;
using System;

public partial class Bullet : CharacterBody2D
{
	int speed = 500;
	
	

	private Vector2 Window;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Window = GetViewportRect().Size;
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
}
