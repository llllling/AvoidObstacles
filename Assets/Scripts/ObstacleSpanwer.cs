using UnityEngine;

public class ObstacleSpanwer : Spanwer
{
    void Reset()
    {
        InitPlacementMinMax(0.5f, 0.8f);
    }

    void Update()
    {
        if (GameManager.instance.IsGameover) return;

        Vector2 randomPos = new(Random.Range(xPosMin, xPosMax), yPos);
        if (Time.time < lastPlacementTime + placementTime) return;

        lastPlacementTime = Time.time;
        
        placementTime = Random.Range(placementMinTime, placementMaxTime);
        prefabs[currentIndex++].transform.position = randomPos;

        if (currentIndex == prefabs.Length)
        {
            currentIndex = 0;
        }
    }
  
  
}
