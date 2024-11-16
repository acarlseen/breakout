using Godot;
using System;

public partial class ScoreDisplay : Label
{
	int _score;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoreEvent.PointsScored += UpdateScore;
		_score = 0;
	}

    private void UpdateScore(int points)
    {
		_score += points;
        Text = $"SCORE: {_score}";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
