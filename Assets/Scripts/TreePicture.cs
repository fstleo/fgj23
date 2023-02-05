using System;
using UnityEngine;

public class TreePicture : MonoBehaviour
{
    [Serializable]
    private class PictureThreshold
    {
        public int Score;
        public GameObject Picture;
    }

    [SerializeField]
    private PictureThreshold [] _thresholds;

    private int _currentThreshold = 0;

    private void Awake()
    {
        ScoresHolder.ScoreChange += CheckThreshold;
    }

    private void CheckThreshold(int scores)
    {
        if (_currentThreshold == _thresholds.Length - 1)
            return;
        if (_thresholds[_currentThreshold + 1].Score <= scores)
        {
            _thresholds[_currentThreshold].Picture.SetActive(false);
            _currentThreshold++;
            _thresholds[_currentThreshold].Picture.SetActive(true);
            SoundManager.PlaySound(SoundId.LevelUp);
        }
    }
}