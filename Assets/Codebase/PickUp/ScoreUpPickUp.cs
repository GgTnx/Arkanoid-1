using System;
using UnityEngine;

    public class ScoreUpPickUp : MonoBehaviour

    {
        [SerializeField] private int _scoreToAdd;
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
            else
            {
                Destroy(gameObject);
            }
        }

        private void PlayAudio()
        {
            if(_applyAudioClip!=null)
            AudioManager.Instanse.PlayOnShot(_applyAudioClip);
        }

        private void PlayVideoEffect()
        {
            
        }

        private void ApplyPickUp()
        {
            GameManager.Instanse.AddScore(_scoreToAdd);
        }
    }
