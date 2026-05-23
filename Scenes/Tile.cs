using Godot;

public partial class Tile : Area2D
{
	public TileData Data =
		new TileData();
		
	private TextureRect portrait;

	private Label label;
	private Sprite2D sprite;

	[Signal]
	public delegate void TileClickedEventHandler(
		Tile tile
	);

	public override void _Ready()
	{
		label =
			GetNode<Label>("Label");

		sprite =
			GetNode<Sprite2D>("Sprite2D");

		InputEvent += OnInputEvent;
		
		portrait=
		GetNode<TextureRect>(
			"Portrait"
		);
	}

	private void OnInputEvent(
		Node viewport,
		InputEvent @event,
		long shapeIdx
	)
	{
		if(
			@event
			is InputEventMouseButton mouse
			&&
			mouse.Pressed
			&&
			mouse.ButtonIndex
			==
			MouseButton.Left
		)
		{
			EmitSignal(
				SignalName.TileClicked,
				this
			);
		}
	}
	
	public void Refresh()
	{
		if(Data.Type==TileType.Center)
		{
			portrait.Visible=false;

			label.Text=
				"🏠\nCentro";

			return;
		}

		if(
			Data.District==null ||
			Data.District.Race==null
		)
		{
			portrait.Visible=false;

			label.Text="⬜";

			return;
		}

		portrait.Visible=true;

		portrait.Texture=
			Data.District.Race.Portrait;

		label.Text=
			$"Lv{Data.District.Level}\n😊{Data.District.Happiness}";
	}
}
