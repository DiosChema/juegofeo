using Godot;
using System.Linq;
using System.Collections.Generic;

public partial class GridManager : Node2D
{
	[Export]
	public PackedScene TileScene;
	private List<RaceData> currentRefugees;
	private GameManager gameManager;

	private const int GRID_SIZE = 5;
	private const int TILE_SIZE = 64;

	private Tile[,] grid =
		new Tile[GRID_SIZE, GRID_SIZE];

	public override void _Ready()
	{
		gameManager =
			GetNode<GameManager>(
				"../GameManager"
			);

		GenerateGrid();

		currentRefugees =
			gameManager.GetRandomRefugees(3);
	}
	
	

	private void GenerateGrid()
	{
		float offsetX =
			-((GRID_SIZE - 1) * TILE_SIZE) / 2f;

		float offsetY =
			-((GRID_SIZE - 1) * TILE_SIZE) / 2f;

		for (int x = 0; x < GRID_SIZE; x++)
		{
			for (int y = 0; y < GRID_SIZE; y++)
			{
				Tile tile =
					TileScene.Instantiate<Tile>();
					
				tile.Data = new TileData();

				if (x == GRID_SIZE / 2 && y == GRID_SIZE / 2)
				{
					tile.Data.Type =
						TileType.Center;

					// El centro no es un distrito
				}
				else
				{
					tile.Data.District =
						new DistrictData();
				}

				tile.Position = new Vector2(
					x * TILE_SIZE + offsetX,
					y * TILE_SIZE + offsetY
				);

				tile.Data.GridX = x;
				tile.Data.GridY = y;

				AddChild(tile);

				grid[x, y] = tile;

				tile.TileClicked +=
					OnTileClicked;

				tile.Refresh();
				
				
			}
		}
	}
	
	private void OnTileClicked(Tile tile)
	{
		// Ignorar centro urbano
		if(
			tile.Data.Type==
			TileType.Center
		)
			return;

		// Crear District si no existe
		if(tile.Data.District==null)
		{
			tile.Data.District=
				new DistrictData();
		}

		// Ya ocupado
		if(
			tile.Data.District.Race
			!=null
		)
			return;

		// Solo permitir construir conectado
		if(
			!HasAdjacentDistrict(
				tile
			)
		)
		{
			GD.Print(
				"No conectado"
			);

			return;
		}

		// Debe existir raza seleccionada
		if(
			GameManager.Instance
			.SelectedRace
			==null
		)
			return;
			
		if(
			!GameManager.Instance
			.CanBuildThisTurn
		)
			return;
			
		GameManager.Instance.AddDistrict(tile);
			
		GameManager.Instance
			.CanBuildThisTurn=
			false;	
	}
	
	private bool HasAdjacentDistrict(Tile tile)
	{
		int[,] directions =
		{
			{-1,0},
			{1,0},
			{0,-1},
			{0,1}
		};

		for(int i=0;i<4;i++)
		{
			int newX=
				tile.Data.GridX+
				directions[i,0];

			int newY=
				tile.Data.GridY+
				directions[i,1];

			if(
				newX<0 ||
				newX>=GRID_SIZE ||
				newY<0 ||
				newY>=GRID_SIZE
			)
				continue;

			Tile otherTile=
				grid[newX,newY];

			if(otherTile==null)
				continue;

			// Centro urbano
			if(
				otherTile.Data.Type==
				TileType.Center
			)
				return true;

			// Distrito normal
			if(
				otherTile.Data.District!=null &&
				otherTile.Data.District.Race!=null
			)
				return true;
		}

		return false;
	}
}
