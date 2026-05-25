using Godot;

public partial class ResourceDisplay : HBoxContainer
{
	[Export]
	public Texture2D Icon;

	[Export]
	public int Amount = 0;

	[Export]
	public int Income = 0;


	private TextureRect _iconNode;
	private RichTextLabel _amountNode;


	public override void _Ready()
	{
		_iconNode = GetNode<TextureRect>("Icon");
		_amountNode = GetNode<RichTextLabel>("Amount");

		UpdateDisplay();
	}


	public void SetValues(int newAmount, int newIncome)
	{
		Amount = newAmount;
		Income = newIncome;

		UpdateDisplay();
	}


	private void UpdateDisplay()
	{
		_iconNode.Texture = Icon;

		string color = "gray";

		if (Income > 0)
			color = "green";

		else if (Income < 0)
			color = "red";

		_amountNode.Text =
			$"{Amount} [color={color}]({Income:+#;-#;0})[/color]";
	}
}
