using Godot;

public partial class ResourceManager : Node
{
	public int Gold=100;

	public int Wood=0;

	public int Stone=0;

	public int Meat=0;

	public int Vegetables=0;

	public void AddGold(
		int amount
	)
	{
		Gold+=amount;
	}

	public void AddResource(
		string resource,
		int amount
	)
	{
		switch(resource)
		{
			case "Wood":
				Wood+=amount;
				break;

			case "Stone":
				Stone+=amount;
				break;

			case "Meat":
				Meat+=amount;
				break;

			case "Vegetables":
				Vegetables+=amount;
				break;
		}
	}

	public void PrintResources()
	{
		GD.Print(
			$"Gold:{Gold} "+
			$"Wood:{Wood} "+
			$"Stone:{Stone} "+
			$"Meat:{Meat} "+
			$"Vegetables:{Vegetables}"
		);
	}
}
