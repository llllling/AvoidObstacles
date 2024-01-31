using UnityEngine;
using Utill;

public class ObstacleSpanwer : Spanwer
{
    void Reset()
    {
        count = 7;
        InitBatchMinMaxTime(0.8f, 1f);
    }

    void Update()
    {
        if (GameManager.instance.IsGameover) return;

        if (!batchInterval.IsExceedTimeInterval()) return;

        batchInterval.lastTime = Time.time;

        batchInterval.timeInterval = GetRandomBatchTime();

        prefabs[currentIndex++].transform.position = new(Random.Range(xPosMin, xPosMax), yPos);
        if (currentIndex == prefabs.Length)
        {
            currentIndex = 0;
        }
    }
  
  
}
