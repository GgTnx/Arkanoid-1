using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    [Header(nameof(PickUpBase))]
    [SerializeField] private AudioClip _applyAudioClip;
    [SerializeField] private GameObject _applyVisualEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(Tags.Platform))
        {
            PlayAudio();
            PlayVideoEffect();
            ApplyPickUp();
            Destroy(gameObject);
        }
    }

    private void PlayAudio()
    {
        if (_applyAudioClip != null)
            AudioManager.Instanse.PlayOnShot(_applyAudioClip);
    }

    private void PlayVideoEffect()
    {

    }

    protected abstract void ApplyPickUp();

}
