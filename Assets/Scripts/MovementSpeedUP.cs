using UnityEngine;
using Utill;

public class MovementSpeedUP : Movement2D
{
    public float speedUpTimeInterval;
    public float scrollIncreaseSpeed;
    public float initSpeed;
    public float maxScrollSpeed;

    private TimeInterval interval;
    void Reset()
    {
        speedUpTimeInterval = 2f;
        scrollIncreaseSpeed = 1.05f;
        initSpeed = 3f;
        maxScrollSpeed = 8f;
        InitMovement(initSpeed, Vector2.up);
    }

    private void Start()
    {
        InitMovementSpeedUP();
    }
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover) return;
       
        MoveAndIntervalSpeedUP();
    }

    public void InitMovementSpeedUP()
    {
        interval = new(speedUpTimeInterval);
        InitMovement(initSpeed, Vector2.up);
    }
    public void MoveAndIntervalSpeedUP()
    {
       
        if (interval.IsExceedTimeInterval())
        {
            interval.lastTime = Time.time;
            if (moveSpeed < maxScrollSpeed)
            {
                moveSpeed *= scrollIncreaseSpeed;
            }
        }
        Move();
    }
}
