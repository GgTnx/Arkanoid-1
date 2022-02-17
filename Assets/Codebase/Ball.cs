using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Veriables

    public Rigidbody2D Rb;
    public float Speed;
    public Vector2 Direction;
    public Transform PlatformTransform;
    public AudioClip _Clip;
    private bool _isStarted;
    private bool _isMagnite = true;

    #endregion
    #region Unity lifecycle

    private void Start()
    {
        if (GameManager.Instanse.NeedAutoPlay)
        {
            StartBall();
        }
    }

    private void Update()
    {
        if(_isStarted)
            return;
        MoveballWithPlatform();
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion
    #region public methods

    public void Restart()
    {
       
    }

    #endregion
    #region Private methods
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,Direction);
    }
    private void OnCollisionEnter2D(Collision2D col)

    {
        AudioManager.Instanse.PlayOnShot(_Clip);
      //  ContactPoint2D sdfsdf;
  //      col.
       // 
       // foreach (ContactPoint2D missileHit in col.contacts)
        {
      //      Vector2 hitPoint = missileHit.point;
            
        }

       // if (col.gameObject.CompareTag(Tags.Platform)&& _isMagnite)
        {
      //     Magnite();
        }
    }
    private void MoveballWithPlatform()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = PlatformTransform.position.x;
        transform.position = currentPosition;
    }
    private void StartBall()
    {
        Rb.velocity = Direction.normalized * Speed;
        _isStarted = true;
    }

    private void Magnite()
    {

        Rb.velocity = Vector2.zero;
        _isStarted = false;
    }

    #endregion



   
}