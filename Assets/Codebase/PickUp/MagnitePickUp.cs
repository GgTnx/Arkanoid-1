
using UnityEngine;

public class MagnitePickUp : PickUpBase
{
    [SerializeField] private AudioClip _applyAudioClip;
    [SerializeField] private GameObject _applyVisualEffect;
    
    
 
    protected override void ApplyPickUp()
    {
        Ball _ball = FindObjectOfType<Ball>();
        _ball._isMagnite = true;
        platform platform = FindObjectOfType<platform>();
        platform.ChangeMagnitPlatform();
    }
}
