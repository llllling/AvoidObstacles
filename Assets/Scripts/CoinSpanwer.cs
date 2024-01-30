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
        if (GameManager.instance.IsGameover) return;

        if (Time.time < lastBatchTime + batchTime) return;

        Vector2 randomPos = new(Random.Range(xPosMin, xPosMax), yPos);
        if (!IsEnablePostion(randomPos)) return;

        lastBatchTime = Time.time;

        batchTime = GetRandomBatchTime();

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
