using Godot;
using System;

public partial class ExperienceManager : Node
{
    float currentExperience = 0;
    int currentLevel = 1;
    float targetExperience = 1;
    const float TARGET_EXPERIENCE_GROWTH = 5;

    [Signal]
    public delegate void ExperienceUpdatedEventHandler(float currentExperience, float targetExperience);

    [Signal]
    public delegate void LevelUpEventHandler(int newLevel);


    public override void _Ready()
    {
        GameEvents.Instance.ExperienceVialCollected += OnExperienceVialCollected;
    }

    public void IncrementExperience(float num)
    {
        currentExperience += Math.Min(currentExperience + num, targetExperience); ;

        EmitSignal(SignalName.ExperienceUpdated, currentExperience, targetExperience);
        if (currentExperience == targetExperience)
        {
            currentLevel += 1;
            targetExperience += TARGET_EXPERIENCE_GROWTH;
            currentExperience = 0;
            EmitSignal(SignalName.ExperienceUpdated, currentExperience, targetExperience);
            EmitSignal(SignalName.LevelUp, currentLevel);
        }
    }

    public void OnExperienceVialCollected(float number)
    {
        IncrementExperience(number);
    }


}
