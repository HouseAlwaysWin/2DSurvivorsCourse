using Godot;
using ScriptsExtension;
using System;

public partial class VialDropComponent : Node
{
    [Export]
    public PackedScene VialScene;

    [Export]
    public Node HealthComponent;

    [Export(PropertyHint.Range, "0,1")]
    public float DropPercent = 0.5f;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        (HealthComponent as HealthComponent).Died += OnDied;
    }

    public void OnDied()
    {

        // if (Utils.Randf() > DropPercent) return;

        if (VialScene == null) return;

        if (Owner is not Node2D) return;

        var spawnPosition = (Owner as Node2D).GlobalPosition;
        var vialInstance = VialScene.Instantiate() as Node2D;
        Owner.GetParent().AddChild(vialInstance);
        vialInstance.GlobalPosition = spawnPosition;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
