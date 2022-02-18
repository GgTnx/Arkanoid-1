
using System;
using UnityEngine;

public class Kuski : MonoBehaviour
{
    #region Variables

    public Rigidbody2D Rb;
    public Vector2 DirectionRight;
    public Vector2 DirectionLeft;
    public float Speed;

    #endregion

    #region private methods

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Tags.BottomWall))
        {
            Destroy(gameObject); 
        }
        
    }

    #endregion

    

 

    #region public methods

    public  void PoletKuskovright()
    {
        Rb.velocity = DirectionRight.normalized * Speed;

    }
    public void PoletKuskovLeft()
    {
        Rb.velocity = DirectionLeft.normalized * Speed;
    }

    #endregion
}
