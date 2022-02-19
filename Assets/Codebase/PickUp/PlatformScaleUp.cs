public class PlatformScaleUp : PickUpBase
{
    protected override void ApplyPickUp()
    {
        platform platform = FindObjectOfType<platform>();
        platform.ScalePlatformUp();
    }
}