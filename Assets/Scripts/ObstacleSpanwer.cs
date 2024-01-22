using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleSpanwer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int count = 10;

    public float placementMinTime = 0.25f;
    public float placementMaxTime = 0.75f;
    private float placementTime;
    private float lastPlacementTime;

    private float xPosMin;
    private float xPosMax;
    private readonly float yPos = -10f;

    private GameObject[] obstacles;
    private int currentIndex = 0;



    void Start()
    {

        CreateObstacles();
        InitXPosMinMax();

        placementTime = 0f;
        lastPlacementTime = 0f;
    }
    void Update()
    {
        if (Time.time < lastPlacementTime + placementTime) return;

        lastPlacementTime = Time.time;
        
        placementTime = Random.Range(placementMinTime, placementMaxTime);

        obstacles[currentIndex++].transform.position = new Vector3(Random.Range(xPosMin, xPosMax), yPos);
        
        if (currentIndex == obstacles.Length)
        {
            currentIndex = 0;
        }

    }
    private void CreateObstacles()
    {
        Vector2 initPosition = new(0, -10f);
        obstacles = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, initPosition, Quaternion.identity);
        }
    }

    private void InitXPosMinMax()
    {
        Tilemap background = FindFirstObjectByType<Tilemap>();
        float offsetX = background.size.x / 2f - 0.7f;

        xPosMin = -offsetX;
        xPosMax = offsetX;
    }
  
}
