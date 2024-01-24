using UnityEngine;
using Utill;

public class ObstacleSpanwer : Spanwer
{
    void Reset()
    {
        count = 7;
        InitPlacementMinMax(0.3f, 0.7f);
    }

    void Update()
    {
        if (GameManager.instance.IsGameover) return;

        if (Time.time < lastPlacementTime + placementTime) return;

        lastPlacementTime = Time.time;
        
        placementTime = Random.Range(placementMinTime, placementMaxTime);

        prefabs[currentIndex++].transform.position = new(Random.Range(xPosMin, xPosMax), yPos);
        if (currentIndex == prefabs.Length)
        {
            currentIndex = 0;
        }
    }
  
  
}
