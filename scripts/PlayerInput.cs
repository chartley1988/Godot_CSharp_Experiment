using Godot;


public partial class PlayerInput : Node
{
	public int playerInput { get; set;} 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        playerInput = GetPlayerInput();
	}
	 
	 public int GetPlayerInput() {
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

    
}