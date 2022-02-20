using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivBlock : MonoBehaviour
{

    #region Veriables

    private int _Score = 30;
    public AudioClip AudioClip;
    public float _radius;
    public LayerMask _Layer;

    #endregion

    #region Privet Methods

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioManager.Instanse.PlayOnShot(AudioClip);
        GameManager.Instanse.AddScore(_Score);
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _radius,_Layer);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.gameObject == gameObject)
            {
                continue;
            }

            Block block = collider.gameObject.GetComponent<Block>();
            block.SeekAndDestroy();
        }
        Destroy(gameObject);
    }

    #endregion
    
    
}
