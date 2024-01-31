using UnityEngine;
using Utill;

public class MovementSpeedUP : Movement2D
{
    private TimeInterval interval;
    private Constract constract;
 
    void Reset()
    {
        InitMovement(constract.initSpeed, Vector2.up);
    }

    void Awake()
    {
        constract = GameManager.instance.constract;
        interval = new(constract.speedUpTimeInterval);
    }

    void Update()
    {
        MoveAndIntervalSpeedUP();
    }

    public void MoveAndIntervalSpeedUP()
    {
       
        if (interval.IsExceedTimeInterval())
        {
            interval.lastTime = Time.time;
            if (moveSpeed >= constract.maxScrollSpeed)
            {
                moveSpeed *= constract.scrollIncreaseSpeed;
            }
        }
        Move();
    }
}
