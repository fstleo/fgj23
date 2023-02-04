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

    private void Awake()
    {
        ScoresHolder.ScoreChange += CheckThreshold;
    }

    private void CheckThreshold(int scores)
    {
        for (int i = _thresholds.Length - 1; i >= 0; i--)
        {
            _thresholds[i].Picture.SetActive(false);
        }

        for (int i = _thresholds.Length - 1; i >= 0; i--)
        {
            var pictureThreshold = _thresholds[i];
            if (scores >= pictureThreshold.Score)
            {
                pictureThreshold.Picture.SetActive(true);
                return;
            }
        }
    }
}