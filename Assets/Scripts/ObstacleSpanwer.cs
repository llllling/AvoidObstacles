using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpanwer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int minCount = 3;
    public int maxCount = 5;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;

    public float xMin;
    public float xMax;

    private float yPos = 0f;

    private GameObject[] obstacles;
    private int currentIndex = 0;

    private Vector2 InitialPosition = new Vector2(0f, 0f);


    void Start()
    {
        int count = Random.Range(minCount, minCount + 1);
        obstacles = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            {
                obstacles[i] = Instantiate(obstaclePrefab, InitialPosition, Quaternion.identity);
            }

        }


    }
    void Update()
    {

    }
}
