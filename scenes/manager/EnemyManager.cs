using Godot;
using System;

public partial class EnemyManager : Node
{
    [Export]
    public PackedScene basicEnemyScene;

    public const int SPAWN_RADIUS = 500;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var timer = GetNode<Godot.Timer>("Timer");
        timer.Timeout += OnTimerTimeout;
    }

    public void OnTimerTimeout()
    {
        var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
        if (player == null) return;

        var randomDirection = Vector2.Right.Rotated(((float)new Random().NextDouble()) * ((float)(Math.PI * 2)));
        var spawnPosition = player.GlobalPosition + (randomDirection * SPAWN_RADIUS);

        var enemy = basicEnemyScene.Instantiate() as Node2D;
        GetParent().AddChild(enemy);
        enemy.GlobalPosition = spawnPosition;
    }

}
