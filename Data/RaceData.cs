using Godot;

public partial class RaceData : Resource
{
	[Export]
	public string RaceName="";

	[Export]
	public Texture2D Portrait;

	[Export]
	public bool Herbivore=false;

	[Export]
	public bool Carnivore=false;

	[Export]
	public bool Omnivore=false;

	[Export]
	public int Diplomacy=1;

	[Export]
	public int Population=1;

	[Export]
	public int Strength=1;

	[Export]
	public int Specialty=1;

	[Export]
	public int Production=1;
}
