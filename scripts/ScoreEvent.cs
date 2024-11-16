
using System;
using System.Runtime.Serialization;

public static class ScoreEvent
{
    public static event Action <int> PointsScored;

    public static void OnScoreEvent(int points)
    {
        PointsScored?.Invoke(points);
    }
}