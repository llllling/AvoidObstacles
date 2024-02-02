using UnityEngine;
using Utill;

public class MovementSpeedUP : Movement2D
{
    public float speedUpTimeInterval;
    public float scrollIncreaseSpeed;
    public float initSpeed;
    public float maxScrollSpeed;
    public string spanwerName;
    private Spanwer spanwer;

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
        if (spanwerName != null && spanwerName != "")
        {
            spanwer = GameObject.Find(spanwerName).GetComponent<Spanwer>();
        }
    }
    public void MoveAndIntervalSpeedUP()
    {
       
        if (interval.IsExceedTimeInterval())
        {
            interval.lastTime = Time.time;
            if (moveSpeed < maxScrollSpeed)
            {
                if (spanwer != null)
                {
                    spanwer.batchMaxTime = (float)(spanwer.batchMaxTime * 0.995);
                    spanwer.batchMinTime = (float)(spanwer.batchMinTime * 0.995);
                }
                moveSpeed *= scrollIncreaseSpeed;
            }
        }
        Move();
    }
}
