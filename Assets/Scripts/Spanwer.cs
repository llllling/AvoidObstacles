using UnityEngine;
using UnityEngine.Tilemaps;
using Utill;

public class Spanwer : MonoBehaviour
{
    public GameObject prefab;
    [HideInInspector]
    public GameObject[] prefabs;
    [HideInInspector]
    public int currentIndex = 0;

    public float batchMinTime;
    public float batchMaxTime;
    
    protected TimeInterval batchInterval = new();

    protected Vector2 positionMin;
    protected Vector2 positionMax;

    [SerializeField]
    protected int count = 10;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover) return;
        
        if (!IsEnableBatch()) return;

        BatchPrefab(GetRandomPositoin());

    }
    protected void Init()
    {
        CreateObstacles();
        InitPositionMinMax();
    }

    protected void InitBatchMinMaxTime(float min, float max)
    {
        batchMinTime = min;
        batchMaxTime = max;
    }

    protected void BatchPrefab(Vector2 position)
    {
        
        if (!prefabs[currentIndex].activeSelf)
        {
            prefabs[currentIndex].SetActive(true);
        }

        prefabs[currentIndex++].transform.position = position;
        if (currentIndex == prefabs.Length)
        {
            currentIndex = 0;
        }
    }

    protected bool IsEnableBatch()
    {
        if (!batchInterval.IsExceedTimeInterval()) return false;

        batchInterval.lastTime = Time.time;

        batchInterval.timeInterval = GetRandomBatchTime();

        return true;
    }
    protected float GetRandomBatchTime()
    {
        return Random.Range(batchMinTime, batchMaxTime);
    }
    
    protected Vector2 GetRandomPositoin()
    {
        return new(Random.Range(positionMin.x, positionMax.x), Random.Range(positionMin.y, positionMax.y));
    }
    private void CreateObstacles()
    {
    
        prefabs = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            prefabs[i] = Instantiate(prefab, GetRandomPositoin(), Quaternion.identity);
            prefabs[i].SetActive(false);
        }
    }

    private void InitPositionMinMax()
    {
        Tilemap background = FindFirstObjectByType<Tilemap>();
        float offsetX = background.size.x / 2f - 0.7f;
        float offsetY = -background.size.y / 2f - 0.2f;
        positionMin = new(-offsetX, offsetY);
        positionMax = new(offsetX, offsetY - background.size.y);
    }


}
