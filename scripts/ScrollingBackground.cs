using Godot;
using System;

public partial class ScrollingBackground : Node2D
{
	[Export(PropertyHint.File, "*.png,*.jpg,*.svg")]
	private Texture2D background_image;

	[Export(PropertyHint.Range, "0,1000")]
	private float speed = (float)500;

	[Export]
	private Vector2 direction = Vector2.Down;

	private ParallaxBackground layer1;
	private ParallaxBackground layer2;
	private TextureRect TextureRect1;
	private TextureRect TextureRect2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		layer1 = (ParallaxBackground)GetNode("ParallaxBackground");
		layer2 = (ParallaxBackground)GetNode("ParallaxBackground2");


		TextureRect1 = 
		(TextureRect)GetNode(
			"ParallaxBackground/ParallaxLayer/TextureRect"
			);
		TextureRect2 =
		(TextureRect)GetNode(
			"ParallaxBackground2/ParallaxLayer/TextureRect"
			);

		GD.Print(TextureRect1);
		GD.Print(TextureRect2);

		TextureRect1.Texture = background_image;
		TextureRect2.Texture = background_image;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(background_image != null)
		{
			layer1.ScrollBaseOffset += speed * direction * (float)delta;
			if (layer1.ScrollBaseOffset.Y >= 1024)
			{
				layer1.ScrollBaseOffset = 
				new Vector2(0, layer1.ScrollBaseOffset.Y - 2047);
			}

			layer2.ScrollBaseOffset += speed * direction * (float)delta;
			if (layer2.ScrollBaseOffset.Y >= 1024)
			{
				layer2.ScrollBaseOffset = 
				new Vector2(0, layer2.ScrollBaseOffset.Y - 2047);
			}
		}

		
	}
}
