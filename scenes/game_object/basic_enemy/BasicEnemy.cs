using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{

    const int MAX_SPEED = 75;
    public HealthComponent HealthComponent;

    // Called when the node enters the scene tree for the first time.
    // public override void _Ready()
    // {
    //     var area2D = GetNode<Area2D>("Area2D");
    //     area2D.AreaEntered += OnAreaEntered;
    //     HealthComponent = GetNode<HealthComponent>("HealthComponent");
    // }

    // private void OnAreaEntered(Area2D otherArea)
    // {
    //     HealthComponent.Damage(100);
    //     // QueueFree();
    // }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var direction = GetDirectionToPlayer();
        Velocity = direction * MAX_SPEED;
        MoveAndSlide();
    }

    private Vector2 GetDirectionToPlayer()
    {
        var playerNodes = GetTree().GetFirstNodeInGroup("player") as Node2D;
        if (playerNodes != null)
        {
            return (playerNodes.GlobalPosition - GlobalPosition).Normalized();
        }
        return Vector2.Zero;
    }
}
