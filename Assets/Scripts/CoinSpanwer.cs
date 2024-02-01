using UnityEngine;

public class CoinSpanwer : Spanwer
{
    void Reset()
    {
        count = 10;
        InitBatchMinMaxTime(0.5f, 1f);
    }

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover) return;

        if (!batchInterval.IsExceedTimeInterval()) return;

        Vector2 randomPos = new(Random.Range(xPosMin, xPosMax), yPos);
        if (!IsEnablePostion(randomPos)) return;

        batchInterval.lastTime = Time.time;

        batchInterval.timeInterval = GetRandomBatchTime();

        if (!prefabs[currentIndex].activeSelf)
        {
            prefabs[currentIndex].SetActive(true);
        }

        prefabs[currentIndex++].transform.position = randomPos;
        if (currentIndex == prefabs.Length)
        {
            currentIndex = 0;
        }
    }


}
