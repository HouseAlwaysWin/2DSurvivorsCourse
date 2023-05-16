using Godot;
using System;

public partial class GameEvents : Node
{

	public static GameEvents Instance;
	public override void _Ready()
	{
		Instance = GetNode<GameEvents>("/root/GameEvents");
	}

	[Signal]
	public delegate void ExperienceVialCollectedEventHandler(float number);
	public void EmitExperienceVialCollected(float number)
	{
		EmitSignal(SignalName.ExperienceVialCollected, number);
	}

}
