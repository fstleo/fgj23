using System;
using UnityEngine;

public class TreePicture : MonoBehaviour
{
    [Serializable]
    private class PictureThreshold
    {
        public int Score;
        public int ActiveRootsNeeded;
        public GameObject Picture;
    }

    public static int RootsNeeded
    {
        get;
        private set;
    }
    
    public static int NextLevelScore
    {
        get;
        private set;
    }
    
    [SerializeField]
    private PictureThreshold [] _thresholds;

    private int _currentThreshold = 0;

    private void Awake()
    {
        ScoresHolder.ScoreChange += CheckThreshold;
        RootsNeeded = _thresholds[_currentThreshold].ActiveRootsNeeded;
    }

    private void CheckThreshold(int scores)
    {
        if (_currentThreshold == _thresholds.Length - 1)
            return;
        if (_thresholds[_currentThreshold + 1].Score <= scores)
        {
            _thresholds[_currentThreshold].Picture.SetActive(false);
            _currentThreshold++;
            var currentLevel = _thresholds[_currentThreshold];
            RootsNeeded = currentLevel.ActiveRootsNeeded;
            NextLevelScore = _thresholds[_currentThreshold + 1].Score;
            currentLevel.Picture.SetActive(true);
            SoundManager.PlaySound(SoundId.LevelUp);
        }
    }
}