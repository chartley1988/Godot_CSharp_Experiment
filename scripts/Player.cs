using System.Drawing;
using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	private int speed;
	
	[Export(PropertyHint.Range, "0,1,")]
	private float acceleration = (float)0.9;

	[Export(PropertyHint.Range, "0,1,")]
	private float friction = (float)0.2;

	private Vector2 _velocity = Vector2.Zero;
	private Gun _gun;

	private Sprite2D PlayerSprite;
	private Vector2 Window;

	

	public override void _Ready()
	{
		PlayerSprite = (Sprite2D)GetNode("Sprite2D");
		_gun = (Gun)GetNode("SingleCannon/Gun");
		Window = GetViewportRect().Size;
		Position = new Vector2(Window.X/2, Window.Y - 25);
	}

	public override void _PhysicsProcess(double delta)
	{
		Node playerInput = (Node)GetNode("Input");
		
		// Player Movement
		int direction = (int)playerInput.Get("playerDirection");
		MovePlayer(direction, delta);

		// Fire Weapon
		bool trigger = (bool)playerInput.Get("playerAction");
		if(trigger == true && _gun != null)
		{
			_gun.FireGun();
		}
	}

	public void MovePlayer(int direction, double delta)
	{
		Vector2 spriteSize = PlayerSprite.Texture.GetSize();
		Vector2 spriteScale = PlayerSprite.Scale;


		if(direction != 0)
		{
			_velocity.X = Mathf.MoveToward
			(
				_velocity.X,
				speed * direction,
				acceleration/(float)delta
			);

		} 

		else

		{
			_velocity.X = Mathf.MoveToward(_velocity.X, 0, friction/(float)delta);
		}
		Velocity = _velocity;
		MoveAndSlide();

		Position = Position.Clamp
		(
			new Vector2(0 + ((spriteSize.X * spriteScale.X)/2),0),
			new Vector2(Window.X - ((spriteSize.X * spriteScale.X)/2),
			Window.Y - (spriteSize.Y * spriteScale.Y))
		);
	}

	
}
