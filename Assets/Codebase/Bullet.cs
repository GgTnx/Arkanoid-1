using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Vector2 Direction;
    public float Speed;

    public void StartBullet()
    {
        Rb.velocity = Direction.normalized * Speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.CompareTag(Tags.Invis))
        {
            Destroy(col.gameObject);
        }
        else if(col.gameObject.CompareTag(Tags.Double))
        {
            DoubleBlock component = col.gameObject.GetComponent<DoubleBlock>();
            component.SeekAndDestroy();
        }
        else if (col.gameObject.CompareTag(Tags.Explosiv))
        {
            ExplosivBlock component = col.gameObject.GetComponent<ExplosivBlock>();
            component.SeekAndDestroy();
        }
        else if(col.gameObject.CompareTag(Tags.Block))
        {
            Block block = col.gameObject.GetComponent<Block>();
            block.SeekAndDestroy();
        }
        else
        {
            return;
        }
        Destroy(gameObject);
    }
}
