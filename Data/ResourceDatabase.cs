using Godot;
using System.Collections.Generic;

public static class ResourceDatabase
{
	public static Dictionary<string, Texture2D>
	Icons = new()
	{
		{
			"Gold",
			GD.Load<Texture2D>(
				"res://Assets/Resources/gold.png"
			)
		},

		{
			"Wood",
			GD.Load<Texture2D>(
				"res://Assets/Resources/wood.png"
			)
		},

		{
			"Stone",
			GD.Load<Texture2D>(
				"res://Assets/Resources/stone.png"
			)
		},

		{
			"Meat",
			GD.Load<Texture2D>(
				"res://Assets/Resources/meat.png"
			)
		},

		{
			"Vegetables",
			GD.Load<Texture2D>(
				"res://Assets/Resources/vegetables.png"
			)
		}
	};
}
