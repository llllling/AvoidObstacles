using UnityEngine;

public class BackgroundScroll : MovementSpeedUP
{
    void Reset()
    {
        InitMovement(3f, Vector2.up);
    }
}
