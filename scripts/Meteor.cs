using Godot;
using System;

public partial class Meteor : CharacterBody2D
{
	public float rotate_speed = 100;
	public float speed = 10000;

    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(double delta)
	{
		RotationDegrees += rotate_speed * (float)delta;
		Velocity = new Vector2(0, speed * (float)delta);
		MoveAndSlide();
	}
}
