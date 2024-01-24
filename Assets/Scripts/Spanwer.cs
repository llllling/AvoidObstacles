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

    public float placementMinTime;
    public float placementMaxTime;
    
    protected float placementTime = 0f;
    protected float lastPlacementTime = 0f;

    protected float xPosMin;
    protected float xPosMax;
    protected readonly float yPos = -10f;

    [SerializeField]
    protected int count = 10;

    void Start()
    {
        Init();

    }
    protected void Init()
    {
        CreateObstacles();
        InitXPosMinMax();
    }

    protected void InitPlacementMinMax(float min, float max)
    {
        placementMinTime = min;
        placementMaxTime = max;
    }

    ///// <summary>
    ///// 파라미터로 받은 위치값에 다른 게임 오브젝트 존재 여부를 체크해서 해당 위치의 사용 가능 여부를 반환한다.
    ///// </summary>
    //protected bool IsEnablePostion(Vector2 pos)
    //{
    //   return !Utills.CheckForObjectAtPoint(pos);
    //}

    private void CreateObstacles()
    {
        Vector2 initPosition = new(0, -10f);
        prefabs = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            prefabs[i] = Instantiate(prefab, initPosition, Quaternion.identity);
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
