using Godot;

public enum TileType
{
	Empty,
	Center,

	Grassland,
	Forest,
	Quarry,
	Lake,
	HuntingGround
}

public partial class TileData : Resource
{
	public TileType Type =
		TileType.Empty;

	public int GridX;

	public int GridY;

	public DistrictData District;
}
