using Godot;
using System;

public partial class GameCamera : Camera2D
{
    public Vector2 TargetPosition = Vector2.Zero;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MakeCurrent();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        AcquireTarget();
        GlobalPosition = GlobalPosition.Lerp(TargetPosition, (float)(1.0 - Math.Exp(-delta * 20)));
    }

    private void AcquireTarget()
    {
        var playerNodes = GetTree().GetNodesInGroup("player");
        if (playerNodes.Count > 0)
        {
            var player = playerNodes[0] as Node2D;
            TargetPosition = player.GlobalPosition;
        }

    }
}
