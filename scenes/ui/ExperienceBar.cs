using Godot;
using System;

public partial class ExperienceBar : CanvasLayer
{
	[Export]
	public Node ExperienceManager;
	private ProgressBar ProgressBar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.ProgressBar = GetNode<ProgressBar>("MarginContainer/ProgressBar");
		ProgressBar.Value = 0;
		((ExperienceManager)ExperienceManager).ExperienceUpdated += OnExperienceUpdate;
	}

	public void OnExperienceUpdate(float currentExperience, float targetExperience)
	{
		var percent = currentExperience / targetExperience;
		ProgressBar.Value = percent;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
