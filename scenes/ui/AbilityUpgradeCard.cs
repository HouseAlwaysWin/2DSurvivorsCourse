using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{

    public Label NameLabel;
    public Label DescriptionLabel;

    [Signal]
    public delegate void SelectedEventHandler();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        NameLabel = GetNode<Label>("%NameLabel");
        DescriptionLabel = GetNode<Label>("%DescriptionLabel");

        GuiInput += OnGuiInput;
    }


    private void OnGuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("left_click"))
        {
            EmitSignal(SignalName.Selected);
        }
    }

    public void SetAbilityUpgrade(AbilityUpgrade upgrade)
    {
        NameLabel.Text = upgrade.Name;
        DescriptionLabel.Text = upgrade.Description;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }
}
