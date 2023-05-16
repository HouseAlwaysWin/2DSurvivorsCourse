using Godot;
using System;

public partial class UpgradeScreen : CanvasLayer
{

    [Export]
    public PackedScene UpgradeCardScene;

    public HBoxContainer CardContainer;

    [Signal]
    public delegate void UpgradeSelectedEventHandler(AbilityUpgrade upgrade);


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CardContainer = GetNode<HBoxContainer>("%CardContainer");

        GetTree().Paused = true;
    }

    public void SetAbilityUpgrades(AbilityUpgrade[] upgrades)
    {
        foreach (var upgrade in upgrades)
        {
            var cardInstance = UpgradeCardScene.Instantiate() as AbilityUpgradeCard;
            CardContainer.AddChild(cardInstance);

            if (cardInstance != null)
            {
                cardInstance.SetAbilityUpgrade(upgrade);
            }

            cardInstance.Selected += () => OnUpgradeSelected(upgrade);
        }
    }

    private void OnUpgradeSelected(AbilityUpgrade upgrade)
    {
        EmitSignal(SignalName.UpgradeSelected, upgrade);
        GetTree().Paused = false;
        QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
