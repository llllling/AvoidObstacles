using UnityEngine;

public class BackgroundScroll : Movement2D
{
    void Reset()
    {
        InitMovement(3f, Vector2.up);
    }
}
