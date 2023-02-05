using UnityEngine;

public class PlaySoundAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private SoundId _soundId;
    
    public void PlaySound()
    {
        SoundManager.PlaySound(_soundId);
    }
}