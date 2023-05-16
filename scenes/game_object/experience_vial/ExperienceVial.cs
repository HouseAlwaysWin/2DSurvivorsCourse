using Godot;
using System;

public partial class ExperienceVial : Node2D
{

    public override void _Ready()
    {
        var area2D = GetNode<Area2D>("Area2D");
        area2D.AreaEntered += OnAreaEntered;
    }

    public void OnAreaEntered(Area2D otherArea)
    {
        GameEvents.Instance.EmitExperienceVialCollected(1);
        QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
