using UnityEngine;

public class CoinSpanwer : Spanwer
{
    void Reset()
    {
        count = 5;
        InitPlacementMinMax(1f, 1.5f);
    }

    void Update()
    {
        if (GameManager.instance.IsGameover) return;

        Vector2 randomPos = new(Random.Range(xPosMin, xPosMax), yPos);
        if (Time.time < lastPlacementTime + placementTime) return;

        lastPlacementTime = Time.time;
        placementTime = Random.Range(placementMinTime, placementMaxTime);

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
