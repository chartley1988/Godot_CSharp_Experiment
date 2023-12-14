using Godot;
using System;

public partial class SoundEffect : AudioStreamPlayer
{

	AudioStream audio;
	public bool variance;
	public float variance_amount;
	public bool play_once = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlaySound() 
	{
		if(Stream == null){
			return;
		}
		if(variance == true)
		{
		var rng = new RandomNumberGenerator();
		var pitchMod = rng.RandfRange(
			PitchScale - (float)variance_amount,
			 PitchScale + (float)variance_amount);
		PitchScale = pitchMod;
		}
		Play();
	}

	private void _on_finished()
	{
		if(play_once){
			QueueFree();
		}
	}
}
