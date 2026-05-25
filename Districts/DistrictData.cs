using Godot;

public partial class DistrictData : Resource
{
	[Export]
	public RaceData Race;

	[Export]
	public int Level=0;

	[Export]
	public int Happiness=50;

	[Export]
	public int Production=5;
}
