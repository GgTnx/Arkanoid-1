using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBallDown : PickUpBase
{
    protected override void ApplyPickUp()
    {
        Ball[] _balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in _balls)
        {
            ball.ScaleDown();
        }
    }
}
