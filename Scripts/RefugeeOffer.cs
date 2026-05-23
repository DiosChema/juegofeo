using Godot;
using System.Collections.Generic;

public partial class RefugeeOffer : Resource
{
	public RaceData Race;

	public int Gold;

	public Dictionary<string,int> Resources =
		new();
}
