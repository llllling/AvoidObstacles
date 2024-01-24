using UnityEngine;

public class CoinSpanwer : Spanwer
{
    void Reset()
    {
        count = 10;
        InitPlacementMinMax(0.5f, 1f);
    }

    void Update()
    {
        if (GameManager.instance.IsGameover) return;

        if (Time.time < lastPlacementTime + placementTime) return;

        Vector2 randomPos = new(Random.Range(xPosMin, xPosMax), yPos);
        if (!IsEnablePostion(randomPos)) return;

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
