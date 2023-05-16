using System.Globalization;
using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
    [Export]
    public Node HealthComponent;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    public void OnAreaEntered(Area2D otherArea)
    {
        if (!(otherArea is HitboxComponent)) return;

        if (HealthComponent == null) return;

        var HitboxComponent = otherArea as HitboxComponent;
        ((HealthComponent)HealthComponent).Damage(HitboxComponent.Damage);
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
