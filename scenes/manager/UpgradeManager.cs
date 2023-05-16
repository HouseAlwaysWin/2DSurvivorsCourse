using System.Linq;
using Godot;
using Models;
using ScriptsExtension;
using System;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{
    [Export]
    public AbilityUpgrade[] UpgradePool;

    [Export]
    public Node ExperienceManager;

    [Export]
    public PackedScene UpgradeScreenScene;

    private Dictionary<string, CurrentUpgrade> _currentUpgrade;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if (ExperienceManager is ExperienceManager)
        {
            (ExperienceManager as ExperienceManager).LevelUp += OnLevelUp;
        }
    }

    public void OnLevelUp(int currentLevel)
    {
        var chosenUpgrade = UpgradePool.PickRandom();
        if (chosenUpgrade == null) return;

        var upgradeScreenInstance = UpgradeScreenScene.Instantiate() as UpgradeScreen;
        AddChild(upgradeScreenInstance);
        upgradeScreenInstance.SetAbilityUpgrades(new[] { chosenUpgrade });
        upgradeScreenInstance.UpgradeSelected += OnUpgradeSelected;

    }

    private void OnUpgradeSelected(AbilityUpgrade upgrade)
    {
        ApplyUpgrade(upgrade);
    }

    public void ApplyUpgrade(AbilityUpgrade upgrade)
    {

        if (_currentUpgrade.ContainsKey(upgrade.Id))
        {
            _currentUpgrade[upgrade.Id].Quantity++;
        }
        else
        {
            _currentUpgrade.Add(upgrade.Id, new CurrentUpgrade
            {
                Resource = upgrade,
                Quantity = 1
            });

        };
        GD.Print(_currentUpgrade);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
