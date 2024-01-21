using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class ObstacleSpanwer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int maxCount = 5;

    private GameObject[] obstacles;


    void Start()
    {

        //int count = Random.Range(minCount, minCount + 1);
        //obstacles = new GameObject[count];
        //for (int i = 0; i < count; i++)
        //{

        //    obstacles[i] = Instantiate(obstaclePrefab, GetRandomPosition(), Quaternion.identity);


        //}

    }
    void Update()
    {

    }

  
}
