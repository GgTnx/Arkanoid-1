using System;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    #region Veriables
    public SpriteRenderer SpriteRenderer;
    public AudioClip AudioClip;
    public int Score = 10;
    private bool _isVisible = false;

    #endregion
    #region Event

    public static event Action CrushInvBlock;

    #endregion
    #region privat methods

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_isVisible)
        {
            AudioManager.Instanse.PlayOnShot(AudioClip);
            GameManager.Instanse.AddScore(Score);
            Destroy(gameObject);
            CrushInvBlock?.Invoke();
        }
        else
        {
            SpriteRenderer.enabled = true;
            AudioManager.Instanse.PlayOnShot(AudioClip);
            _isVisible = true;
        }

    }

  

    #endregion
   
  
}
