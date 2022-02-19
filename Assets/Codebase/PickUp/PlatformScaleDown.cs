
using UnityEngine;

public class PlatformScaleDown : PickUpBase
{
    protected override void ApplyPickUp()
    {
        platform platform = FindObjectOfType<platform>();
        platform.ScalePlatformDown();
    }
}
