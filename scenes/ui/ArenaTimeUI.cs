using Godot;
using System;

public partial class ArenaTimeUI : CanvasLayer
{

    [Export]
    public Node ArenaTimeManager;
    public Label _label;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _label = GetNode<Label>("MarginContainer/Label");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (ArenaTimeManager == null) return;
        var timeElapsed = ((ArenaTimeManager)ArenaTimeManager).GetTimeElapsed();
        _label.Text = format_time(TimeSpan.FromSeconds(timeElapsed));
    }

    public string format_time(TimeSpan timeElapsed)
    {
        // string formattedTimeElapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
        //             timeElapsed.Hours,
        //             timeElapsed.Minutes,
        //             timeElapsed.Seconds,
        //             timeElapsed.Milliseconds);
        string formattedTimeElapsed = string.Format("{0:D2}:{1:D2}", timeElapsed.Minutes, timeElapsed.Seconds);

        return formattedTimeElapsed;
    }
}
