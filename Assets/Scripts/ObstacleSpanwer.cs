using UnityEngine;

public class ObstacleSpanwer : Spanwer
{
    private bool isFirstBatch = true;
    private Vector2 initPosition;
    void Reset()
    {
        count = 7;
        InitBatchMinMaxTime(0.8f, 1f);
    }

    void Start()
    {
        Init();
        initPosition = new(Random.Range(positionMin.x, positionMax.x), -10f);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameover) return;

        if (!IsEnableBatch()) return;

        Vector2 position = isFirstBatch ? initPosition : GetRandomPositoin();
        BatchPrefab(position);

        if (isFirstBatch)
        {
            isFirstBatch = false;
        }
    }

}
