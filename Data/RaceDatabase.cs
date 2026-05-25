using Godot;
using System.Collections.Generic;

public partial class RaceDatabase : Node
{
	public static List<RaceData> Races =
	[
		new RaceData()
		{
			RaceName="Human",
			Portrait=GD.Load<Texture2D>(
		        "res://Assets/Portraits/human_Portrait.png"
			),
			Omnivore=true,
			Diplomacy=2,
			Population=2,
			Strength=2,
			Specialty=3,
			Production=3
		},

		new RaceData()
		{
			RaceName="Elfs",
			Portrait=GD.Load<Texture2D>(
		    	"res://Assets/Portraits/elf_Portrait.png"
			),
			Herbivore=true,
			Diplomacy=1,
			Population=1,
			Strength=2,
			Specialty=4,
			Production=2
		},

		new RaceData()
		{
			RaceName="Orcs",
			Portrait=GD.Load<Texture2D>(
		        "res://Assets/Portraits/orc_Portrait.png"
			),
			Carnivore=true,
			Diplomacy=2,
			Population=2,
			Strength=3,
			Specialty=3,
			Production=2
		},
		
		new RaceData()
		{
			RaceName="Skaven",
			Portrait=GD.Load<Texture2D>(
		        "res://Assets/Portraits/skaven_Portrait.png"
			),
			Omnivore=true,
			Diplomacy=1,
			Population=3,
			Strength=1,
			Specialty=1,
			Production=4
		},

		new RaceData()
		{
			RaceName="Harpies",
			Portrait=GD.Load<Texture2D>(
		        "res://Assets/Portraits/harpy_Portrait.png"
			),
			Herbivore=true,
			Diplomacy=3,
			Population=2,
			Strength=2,
			Specialty=2,
			Production=3
		},

		new RaceData()
		{
			RaceName="Kobolds",
			Portrait=GD.Load<Texture2D>(
		        "res://Assets/Portraits/kobold_Portrait.png"
			),
			Carnivore=true,
			Diplomacy=2,
			Population=3,
			Strength=1,
			Specialty=3,
			Production=3
		}
		
	];
}
