using System;
using UnityEngine;

public class ScoresHolder
{

    public static event Action<int> ScoreChange;
    private const string ScoreKey = "Scores";

    public static int MaximumScores 
    {
        get => PlayerPrefs.GetInt(ScoreKey, 0);
        private set => PlayerPrefs.SetInt(ScoreKey, value);
    }

    private static int _scores;
    public static int Scores
    {
        get => _scores;
        set
        {
            _scores = value;
            ScoreChange?.Invoke(_scores);
            if (_scores > MaximumScores)
            {
                MaximumScores = _scores;
            }
        }
    }

}