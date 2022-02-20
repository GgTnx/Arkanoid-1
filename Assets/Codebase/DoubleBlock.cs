using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBlock : MonoBehaviour
{
    #region Veriables
    public GameObject _kuskiPrefab;
    public Sprite Sprite;
    public AudioClip AudioClip;
    public SpriteRenderer _renderer;
    public int Score = 20;
    private bool _oneHit;
    #endregion

    #region Event

    // public static event Action CrushInvBlock;

    #endregion

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_oneHit)
        {
            SeekAndDestroy();
          
        }
        else
        {
            _renderer.sprite = Sprite;
            AudioManager.Instanse.PlayOnShot(AudioClip);
            _oneHit = true;
        }
    }

    public void SeekAndDestroy()
    {
        AudioManager.Instanse.PlayOnShot(AudioClip);
        GameManager.Instanse.AddScore(Score);
        DestroyObject();
    }
    private void DestroyObject()
    {
        GameObject instantiate = Instantiate(_kuskiPrefab, transform.position, Quaternion.identity);
        Kuski kuski = instantiate.GetComponent<Kuski>();
        kuski.PoletKuskovright();
        GameObject instantiate1 = Instantiate(_kuskiPrefab, transform.position, Quaternion.identity);
        Kuski kuski1 = instantiate1.GetComponent<Kuski>();
        kuski1.PoletKuskovLeft();
        Destroy(gameObject);  
        
    }
}