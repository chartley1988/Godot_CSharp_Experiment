using Godot;


public partial class PlayerInput : Node
{
	public int playerDirection { get; set;} 
	public bool playerAction { get; set;} 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        playerDirection = GetPlayerDirection();
		playerAction = GetPlayerAction();
	}
	 
	public int GetPlayerDirection() {
		if (Input.IsActionPressed("ui_left"))
		{
			return -1;
		}

		if (Input.IsActionPressed("ui_right"))
		{
			return 1;
		}

		return 0;
	}

	public bool GetPlayerAction() {
		if (Input.IsActionPressed("ui_accept"))
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
}