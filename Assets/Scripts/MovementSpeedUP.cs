using UnityEngine;
using Utill;

public class MovementSpeedUP : MonoBehaviour
{
    [HideInInspector]
    public Spanwer spanwer;
    [SerializeField]
    private Vector2 moveDirection = Vector2.up;

    private GameManager gameManager;
    private TimeInterval interval;

    private void Start()
    {
        InitMovementSpeedUP();
    }
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover) return;

        MoveAndIntervalSpeedUP();
    }

    protected void InitMovementSpeedUP()
    {
        gameManager = GameManager.instance;
        interval = new(gameManager.intervalTimeForSpeed);
    }
    protected void MoveAndIntervalSpeedUP()
    {

        if (interval.IsExceedTimeInterval())
        {
            interval.lastTime = Time.time;

            if (gameManager.IsEnableScrollUp)
            {
                gameManager.ScrollSpeedUp();
                if (spanwer != null)
                {
                    spanwer.DecreaseBatchTime((1 - gameManager.initSpeed / gameManager.currentSpeed) * 0.02f);
                }
            }

        }
        Move();
    }

    protected void Move()
    {
        transform.position = (Vector2)transform.position + gameManager.currentSpeed * Time.deltaTime * moveDirection;
    }
}
