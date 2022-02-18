using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBlock : MonoBehaviour
{
    #region Veriables
    public Sprite Sprite;
    public AudioClip AudioClip;
    public SpriteRenderer _renderer;
    public int Score = 20;
    private bool _oneHit;

    #endregion

    private void Awake()
    {
        //_renderer.sprite = Sprite[0];
    }

    #region Event

    // public static event Action CrushInvBlock;

    #endregion

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_oneHit)
        {
            AudioManager.Instanse.PlayOnShot(AudioClip);
            GameManager.Instanse.AddScore(Score);
            Destroy(gameObject);
            // CrushInvBlock?.Invoke();
        }
        else
        {
            _renderer.sprite = Sprite;
            AudioManager.Instanse.PlayOnShot(AudioClip);
            _oneHit = true;
        }
    }
}