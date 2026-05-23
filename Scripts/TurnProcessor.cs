using Godot;

public partial class TurnProcessor : Node
{
	public void ProcessTurn()
	{
		GameManager gameManager=
			GameManager.Instance;

		foreach(
			Tile tile
			in gameManager.GetDistricts()
		)
		{
			if(
				tile.Data.District.Race
				== null
			)
				continue;

			ProcessDistrict(
				tile
			);
		}

		gameManager.Resources
			.PrintResources();
	}

	private void ProcessDistrict(
		Tile tile
	)
	{
		var race=
			tile.Data.District.Race;

		var resources=
			GameManager.Instance
			.Resources;

		// Oro base
		resources.AddGold(
			race.Production
		);

		// Producción según dieta
		if(race.Carnivore)
		{
			resources.AddResource(
				"Meat",
				race.Population
			);
		}

		if(race.Herbivore)
		{
			resources.AddResource(
				"Vegetables",
				race.Population
			);
		}

		if(race.Omnivore)
		{
			resources.AddResource(
				"Meat",
				1
			);

			resources.AddResource(
				"Vegetables",
				1
			);
		}

		// Producción especial
		resources.AddResource(
			"Wood",
			race.Specialty
		);

		GD.Print(
			$"{race.RaceName} produjo"
		);
	}
}
