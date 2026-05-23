using Godot;

public partial class RefugeePanel : Panel
{
	private VBoxContainer container;

	public override void _Ready()
	{
		container=
			GetNode<VBoxContainer>(
				"VBoxContainer"
			);

		MouseFilter=
			MouseFilterEnum.Stop;
	}

	public void Refresh()
	{
		if(container==null)
			return;

		foreach(Node child in container.GetChildren())
		{
			child.QueueFree();
		}

		GameManager gameManager=
			GameManager.Instance;

		Label title=
			new();

		title.Text=
			"Nuevos refugiados";

		container.AddChild(
			title
		);

		foreach(var offer in gameManager.CurrentOffers)
		{
			Button button=
				new();

			button.CustomMinimumSize=
				new Vector2(
					350,
					55
				);

			button.SizeFlagsHorizontal=
				Control.SizeFlags.ExpandFill;

			HBoxContainer row=
				new();

			row.SizeFlagsHorizontal=
				Control.SizeFlags.ExpandFill;

			// Portrait
			TextureRect portrait=
				new();

			portrait.Texture=
				offer.Race.Portrait;

			portrait.CustomMinimumSize=
				new Vector2(
					40,
					60
				);

			portrait.Size=
				new Vector2(
					40,
					60
				);

			portrait.ExpandMode=
				TextureRect
				.ExpandModeEnum
				.IgnoreSize;

			portrait.StretchMode=
				TextureRect
				.StretchModeEnum
				.KeepAspectCentered;

			// Información
			VBoxContainer info=
				new();

			info.SizeFlagsHorizontal=
				Control.SizeFlags.ExpandFill;

			Label raceLabel=
				new();

			raceLabel.Text=
				offer.Race.RaceName;

			HBoxContainer resourceRow=
				new();

			resourceRow.AddChild(
				CreateResourceDisplay(
					"Gold",
					offer.Gold
				)
			);

			foreach(
				var resource
				in offer.Resources
			)
			{
				resourceRow.AddChild(
					CreateResourceDisplay(
						resource.Key,
						resource.Value
					)
				);
			}

			info.AddChild(
				resourceRow
			);

			row.AddChild(
				portrait
			);

			row.AddChild(
				info
			);

			button.AddChild(
				row
			);

			var selectedOffer=
				offer;

			button.Pressed +=
			() =>
			SelectOffer(
				selectedOffer
			);

			container.AddChild(
				button
			);
		}
	}
	
	private Control CreateResourceDisplay(
		string resource,
		int amount
	)
	{
		HBoxContainer box=
			new();

		TextureRect icon=
			new();

		icon.Texture=
			ResourceDatabase
			.Icons[resource];

		icon.CustomMinimumSize=
			new Vector2(
				16,
				16
			);

		icon.ExpandMode=
			TextureRect
			.ExpandModeEnum
			.IgnoreSize;

		icon.StretchMode=
			TextureRect
			.StretchModeEnum
			.KeepAspectCentered;

		Label label=
			new();

		label.Text=
			amount.ToString();

		box.AddChild(
			icon
		);

		box.AddChild(
			label
		);

		return box;
	}

	private void SelectOffer(
		RefugeeOffer offer
	)
	{
		GameManager.Instance
			.SelectedRace=
			offer.Race;
			
		GameManager.Instance.CanBuildThisTurn = true;

		GetParent<Control>()
			.Visible=
			false;
	}
}
