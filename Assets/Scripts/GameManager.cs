using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// ���� ���� ��ũ�� �ӵ�
    ///</summary>
    [HideInInspector]
    public float currentSpeed;
    /// <summary>
    /// ���� ���� ��ũ�� �ӵ�
    ///</summary>
    public float initSpeed = 3f;
    /// <summary>
    /// ��ũ�� ���� �ӵ�
    ///</summary>
    public float increaseSpeed = 0.05f;
    /// <summary>
    /// ��� ������ �����ϱ� ���� �ִ� ��ũ�� �ӵ�
    /// </summary>
    public float maxScrollSpeed = 8f;
    /// <summary>
    /// ��ũ�� ���� ���͹�
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
