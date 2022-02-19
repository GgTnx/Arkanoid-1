
public class ScaleBallUp : PickUpBase
{
    protected override void ApplyPickUp()
    {
        Ball[] _balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in _balls)
        {
            ball.ScaleUp();
        }
    }
}
