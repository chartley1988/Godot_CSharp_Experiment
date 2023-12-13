using Godot;
using System;
using System.Runtime;

public partial class Meteor : CharacterBody2D
{
	public float rotate_speed = 100;
	public float speed = 10000;

	private Node2D main;
	private Vector2 Window;

    public override void _Ready()
    {
        main = (Node2D)GetParent();
		Window = GetViewportRect().Size;
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
			QueueFree();
			}
			else
			{
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
}
