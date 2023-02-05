using TMPro;
using UnityEngine;

public class RootsLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _needRoots;
    [SerializeField] private TextMeshProUGUI _activeRoots;
    [SerializeField] private TextMeshProUGUI _nextLevelScores;

    private void Update()
    {
        _needRoots.text = TreePicture.RootsNeeded.ToString();
        _activeRoots.text = TreeRoot.ActiveRoots.ToString();
        _nextLevelScores.text = TreePicture.NextLevelScore.ToString();
    }
}