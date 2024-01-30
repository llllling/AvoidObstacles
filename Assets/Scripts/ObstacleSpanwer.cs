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

        if (Time.time < lastBatchTime + batchTime) return;

        lastBatchTime = Time.time;

        batchTime = GetRandomBatchTime();

        prefabs[currentIndex++].transform.position = new(Random.Range(xPosMin, xPosMax), yPos);
        if (currentIndex == prefabs.Length)
        {
            currentIndex = 0;
        }
    }
  
  
}
