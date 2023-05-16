using Godot;
using System;

public partial class Player : CharacterBody2D
{
    const int MAX_SPEED = 100;
    const int ACCELERATION_SMOOTHING = 25;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var movementVector = GetMovementVector();
        var direction = movementVector.Normalized();
        var targetVelocity = direction * MAX_SPEED;

        Velocity = Velocity.Lerp(targetVelocity, (float)(1 - Math.Exp(-delta * ACCELERATION_SMOOTHING)));

        MoveAndSlide();
    }

    public Vector2 GetMovementVector()
    {
        var x_movement = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        var y_movement = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        return new Vector2(x_movement, y_movement);
    }

}
