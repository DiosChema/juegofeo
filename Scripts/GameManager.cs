using Godot;
using System.Collections.Generic;

public partial class GameManager : Node
{
	public static GameManager Instance;
	public TurnProcessor TurnProcessor;
	
	public ResourceManager Resources;

	private List<Tile> districts= new();

	public int Gold=0;

	public int Wood=0;

	public int Stone=0;

	public int Meat=0;

	public int Vegetables=0;

	public int Turn = 1;

	public RaceData SelectedRace;

	private Label turnLabel;
	private Button endTurnButton;
	
	public List<RefugeeOffer>
		CurrentOffers = [];
		
	public bool CanBuildThisTurn=false;		

	public override void _Ready()
	{
		Instance = this;
		
		Resources=
			new();

		AddChild(
			Resources
		);

		TurnProcessor=
			new();

		AddChild(
			TurnProcessor
		);
		
		GenerateRefugees();

		CallDeferred(
			nameof(InitializeGame)
		);
		
		TurnProcessor=
			new();

		AddChild(
			TurnProcessor
		);

		turnLabel =
			GetNode<Label>(
				"../UI/TurnLabel"
			);

		endTurnButton =
			GetNode<Button>(
				"../UI/EndTurnButton"
			);

		endTurnButton.Pressed +=
			EndTurn;
	}

	private void EndTurn()
	{
		Turn++;

		SelectedRace = null;
		
		CanBuildThisTurn=false;
		
		TurnProcessor
			.ProcessTurn();

		GenerateRefugees();

		var overlay=
			GetNode<ColorRect>(
				"../UI/RefugeeOverlay"
			);

		var panel=
			GetNode<RefugeePanel>(
				"../UI/RefugeeOverlay/RefugeePanel"
			);

		overlay.Visible=true;

		panel.Refresh();

		GD.Print(
			$"Turno {Turn}"
		);

		UpdateUI();
	}

	private void UpdateUI()
	{
		turnLabel.Text =
			$"Turno: {Turn}";
	}

	public void AddDistrict(
		Tile tile
	)
	{
		tile.Data.District.Race=
			SelectedRace;

		tile.Data.District.Level=1;

		tile.Data.District.Happiness=50;

		tile.Data.District.Production=
			SelectedRace.Production;

		tile.Refresh();

		RegisterDistrict(
			tile
		);

		GD.Print(
			$"Nuevo distrito: " +
			$"{SelectedRace.RaceName}"
		);
	}
	
	public void RegisterDistrict(
		Tile tile
	)
	{
		if(
			!districts.Contains(
				tile
			)
		)
		{
			districts.Add(
				tile
			);
		}
	}

	public List<Tile>
	GetDistricts()
	{
		return districts;
	}

	public List<RaceData> GetRandomRefugees(
		int amount)
	{
		List<RaceData> options=[];

		List<RaceData> pool=
			new(RaceDatabase.Races);

		RandomNumberGenerator rng=new();

		while(
			options.Count<amount &&
			pool.Count>0
		)
		{
			int index=
				rng.RandiRange(
					0,
					pool.Count-1
				);

			options.Add(
				pool[index]
			);

			pool.RemoveAt(
				index
			);
		}

		return options;
	}
	
	public void GenerateRefugees()
	{
		CurrentOffers.Clear();

		RandomNumberGenerator rng =
			new();

		string[] resources =
		{
			"Wood",
			"Stone",
			"Meat",
			"Vegetables"
		};

		int amount =
			rng.RandiRange(
				2,
				5
			);

		List<RaceData> pool =
			new(RaceDatabase.Races);

		while(
			CurrentOffers.Count < amount &&
			pool.Count > 0
		)
		{
			int raceIndex =
				rng.RandiRange(
					0,
					pool.Count-1
				);

			RaceData race =
				pool[raceIndex];

			pool.RemoveAt(
				raceIndex
			);

			RefugeeOffer offer =
				new();

			offer.Race =
				race;

			offer.Gold =
				rng.RandiRange(
					100,
					200
				);

			List<string> resourcePool =
			new(resources);

			for(int i=0;i<2;i++)
			{
				int resourceIndex =
					rng.RandiRange(
						0,
						resourcePool.Count-1
					);

				string resource =
					resourcePool[
						resourceIndex
					];

				resourcePool.RemoveAt(
					resourceIndex
				);

				offer.Resources[
					resource
				] =
				rng.RandiRange(
					5,
					10
				);
			}

			CurrentOffers.Add(
				offer
			);
		}
		
		foreach(var offer in CurrentOffers)
		{
			GD.Print(
				$"{offer.Race.RaceName}"
			);

			GD.Print(
				$"🪙 {offer.Gold}"
			);

			foreach(var resource in offer.Resources)
			{
				string icon="";

				switch(resource.Key)
				{
					case "Wood":
						icon="🪵";
						break;

					case "Stone":
						icon="🪨";
						break;

					case "Meat":
						icon="🥩";
						break;

					case "Vegetables":
						icon="🥬";
						break;
				}

				GD.Print(
					$"{icon} {resource.Value}"
				);
			}

			GD.Print("--------");
		}
	}
		
	private void InitializeGame()
	{
		var overlay=
			GetNode<ColorRect>(
				"../UI/RefugeeOverlay"
			);

		var panel=
			GetNode<RefugeePanel>(
				"../UI/RefugeeOverlay/RefugeePanel"
			);

		overlay.Visible=true;

		panel.Refresh();

		UpdateUI();
	}
}
