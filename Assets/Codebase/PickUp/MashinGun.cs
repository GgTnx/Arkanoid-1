
using UnityEngine;

public class MashinGun : PickUpBase
{
    [SerializeField] private AudioClip _applyAudioClip;
    [SerializeField] private GameObject _applyVisualEffect;
   

    protected override void ApplyPickUp()
    {
        platform _platform = FindObjectOfType<platform>();
        _platform._isMashinGun = true;

    }
}
