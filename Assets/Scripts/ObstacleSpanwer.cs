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


    void Start()
    {
        Vector2 backgroundPos = GetComponent<BackgroundLoop>().transform.position;
        Vector2 initialPos = new Vector2(0, 0);
        int count = Random.Range(minCount, minCount + 1);
        obstacles = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            {
                obstacles[i] = Instantiate(obstaclePrefab, initialPos, Quaternion.identity);
            }

        }


    }
    void Update()
    {

    }
}
