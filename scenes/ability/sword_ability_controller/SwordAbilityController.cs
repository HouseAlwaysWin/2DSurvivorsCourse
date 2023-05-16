using System.Globalization;
using System.Threading;
using Godot;
using System;
using System.Linq;
using Godot.Collections;
using ScriptsExtension;

public partial class SwordAbilityController : Node
{

    [Export]
    public double MAX_RANGE = 150;
    [Export]
    public PackedScene SwordAbility;

    private float damage = 5f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var timer = GetNode<Godot.Timer>("Timer");
        timer.Timeout += OnTimerTimeout;

    }

    // // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(double delta)
    // {
    // }

    public void OnTimerTimeout()
    {
        var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
        if (player == null) return;

        var enemies = GetTree().GetNodesInGroup("enemy").Select(e => (Node2D)e).ToList();

        enemies = enemies.Where(e => e.GlobalPosition.DistanceSquaredTo(player.GlobalPosition) < Math.Pow(MAX_RANGE, 2)).ToList();

        if (enemies.Count == 0) return;

        enemies.Sort<Node2D>((a, b) =>
        {
            var a_distance = a.GlobalPosition.DistanceSquaredTo(player.Position);
            var b_distance = b.GlobalPosition.DistanceSquaredTo(player.Position);
            var result = a_distance < b_distance;
            return result ? 1 : -1;
        });

        var swordInstance = SwordAbility.Instantiate() as SwordAbility;
        player.GetParent().AddChild(swordInstance);
        swordInstance.HitboxComponent.Damage = damage;

        swordInstance.GlobalPosition = enemies.FirstOrDefault().GlobalPosition;
        Random rand = new Random();
        swordInstance.GlobalPosition += Vector2.Right.Rotated((float)rand.NextDouble() * (float)(2 * Math.PI)) * 4;

        var enemyDirection = enemies.FirstOrDefault().GlobalPosition - swordInstance.GlobalPosition;
        swordInstance.Rotation = enemyDirection.Angle();

    }
}
