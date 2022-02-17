using System;
using UnityEngine;

public class platform : MonoBehaviour
{

    #region Veriables

    private Transform _ballTransform;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _ballTransform = FindObjectOfType<Ball>().transform;
        
    }

    private void Update()
    {
        if (GameManager.Instanse.NeedAutoPlay)
        {
            MovePlatformWithBall();
        }
        else
        {
            MovePlatformWithmouse();
        }
        
    }

    

    #endregion

    #region Privet Methods

    private void MovePlatformWithmouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 currentPosition = transform.position;
        currentPosition.x = worldPosition.x;
        transform.position = currentPosition;
    }

    private void MovePlatformWithBall()
    {
        Vector3 ballworldPosition = _ballTransform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = ballworldPosition.x;
        transform.position = currentPosition;
    }

    #endregion
}
