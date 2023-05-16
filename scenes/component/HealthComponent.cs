using Godot;
using System;

public partial class HealthComponent : Node
{


    [Signal]
    public delegate void DiedEventHandler();

    [Export]
    public float MaxHealth = 10;
    public float CurrentHealth;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(float damage)
    {

        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        CallDeferred(nameof(CheckDeath));
    }

    public void CheckDeath()
    {
        if (CurrentHealth == 0)
        {
            EmitSignal(SignalName.Died);
            Owner.QueueFree();
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
