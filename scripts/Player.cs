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
	private Sprite2D PlayerSprite;
	private Vector2 Window;

	

	public override void _Ready()
	{
		PlayerSprite = (Sprite2D)GetNode("Sprite2D");
		Window = GetViewportRect().Size;
		Position = new Vector2(Window.X/2, Window.Y - 50);
	}

	public override void _PhysicsProcess(double delta)
	{
		Node playerInput = (Node)GetNode("Input");
		int direction = (int)playerInput.Get("playerInput");
		MovePlayer(direction, delta);

	}

	public void MovePlayer(int direction, double delta)
	{
		Vector2 spriteSize = PlayerSprite.Texture.GetSize();


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
			new Vector2(0 + (spriteSize.X/2),0),
			new Vector2(Window.X - (spriteSize.X/2),
			Window.Y - spriteSize.Y)
		);
	}
}

public class delta
{
}