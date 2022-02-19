using System;
using UnityEngine;

    public class ScoreUpPickUp : PickUpBase

    {
        [SerializeField] private int _scoreToAdd;
        [SerializeField] private AudioClip _applyAudioClip;
        [SerializeField] private GameObject _applyVisualEffect;


        protected override void ApplyPickUp()
        {
            GameManager.Instanse.AddScore(_scoreToAdd);
        }
    }
