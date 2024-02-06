using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// 현재 게임 스크롤 속도
    ///</summary>
    [HideInInspector]
    public float currentSpeed;
    /// <summary>
    /// 최초 게임 스크롤 속도
    ///</summary>
    public float initSpeed = 3f;
    /// <summary>
    /// 스크롤 증가 속도
    ///</summary>
    public float increaseSpeed = 0.05f;
    /// <summary>
    /// 계속 증가를 방지하기 위한 최대 스크롤 속도
    /// </summary>
    public float maxScrollSpeed = 8f;
    /// <summary>
    /// 스크롤 증가 인터벌
    /// </summary>
    public float intervalTimeForSpeed = 2f;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject managerObject = new("GameManager");
                    instance = managerObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public bool IsGameover { get; private set; } = false;
    public int Score { get; private set; } = 0;

    public bool IsEnableScrollUp
    {
        get
        {
            return currentSpeed <= maxScrollSpeed;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Clear();
        } else
        {
            Destroy(gameObject);
        }
    }

    public void OnPlayerDead()
    {
        SoundManager.Instance.PlayDie();

        IsGameover = true;
    }

    public void AddScore(int score)
    {
        SoundManager.Instance.PlayAddScore();

        Score += score;
    }


    public void ScrollSpeedUp()
    {
        currentSpeed += increaseSpeed;
    }

    public void Clear()
    {
        IsGameover = false;
        Score = 0;
        currentSpeed = initSpeed;
    }
}
