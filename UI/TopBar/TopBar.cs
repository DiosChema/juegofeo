using Godot;

public partial class TopBar : Control
{
	private ResourceDisplay _gold;
	private ResourceDisplay _meat;
	private ResourceDisplay _vegetables;
	private ResourceDisplay _wood;
	private ResourceDisplay _stone;
	private ResourceDisplay _population;


	public override void _Ready()
	{
		_gold = GetNode<ResourceDisplay>(
			"MarginContainer/HBoxContainer/Gold");

		_meat = GetNode<ResourceDisplay>(
			"MarginContainer/HBoxContainer/Meat");

		_vegetables = GetNode<ResourceDisplay>(
			"MarginContainer/HBoxContainer/Vegetables");

		_wood = GetNode<ResourceDisplay>(
			"MarginContainer/HBoxContainer/Wood");

		_stone = GetNode<ResourceDisplay>(
			"MarginContainer/HBoxContainer/Stone");

		_population = GetNode<ResourceDisplay>(
			"MarginContainer/HBoxContainer/Population");
	}
	
	public void UpdateResources(
		int gold,
		int goldIncome,
		int meat,
		int meatIncome,
		int vegetables,
		int vegetablesIncome,
		int wood,
		int woodIncome,
		int stone,
		int stoneIncome,
		int population,
		int pupulationIncome)
	{
		_gold.SetValues(gold,goldIncome);

		_meat.SetValues(meat,meatIncome);
		
		_vegetables.SetValues(vegetables,vegetablesIncome);
		
		_wood.SetValues(wood,woodIncome);
		
		_stone.SetValues(stone,stoneIncome);
		
		_population.SetValues(population,pupulationIncome);
	}
}
