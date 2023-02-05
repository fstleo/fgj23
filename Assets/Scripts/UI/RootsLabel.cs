using TMPro;
using UnityEngine;

public class RootsLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _needRoots;
    [SerializeField] private TextMeshProUGUI _activeRoots;
    [SerializeField] private TextMeshProUGUI _nextLevelScores;
    [SerializeField] private TextMeshProUGUI _maximumActiveRoots;

    private void Update()
    {
        if (_needRoots != null)
        {
            _needRoots.text = TreePicture.RootsNeeded.ToString();
        }

        if (_activeRoots != null)
        {
            _activeRoots.text = TreeRoot.ActiveRoots.ToString();
        }

        if (_nextLevelScores != null)
        {
            _nextLevelScores.text = TreePicture.NextLevelScore.ToString();
        }
        
        if (_maximumActiveRoots != null)
        {
            _maximumActiveRoots.text = TreeRoot.MaximumActiveRoots.ToString();    
        }
    }
}