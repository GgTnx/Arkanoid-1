
using UnityEngine;

public class TripleBallPickUp : PickUpBase
{
    [SerializeField] private int _ballcount;
    protected override void ApplyPickUp()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball _ball in balls)
        {
            for (int i = 0; i < _ballcount; i++)
            {
                Ball ball = FindObjectOfType<Ball>();
                Ball newball = Instantiate(ball);
                newball.StartBall();
            }
        }
        
    }

  
}
