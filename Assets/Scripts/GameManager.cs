using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    public GameObject gameOverObj;

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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�.");
            Destroy(gameObject);
        }

    }

    void Start()
    {
        currentSpeed = initSpeed;
    }
    public void OnPlayerDead()
    {
        SoundControll.instance.PlayDie();

        scoreText.gameObject.SetActive(false);

        gameOverObj.transform.Find("LastScore").transform.GetChild(0).GetComponent<TMP_Text>().text = scoreText.text;

        IsGameover = true;

        gameOverObj.SetActive(true);

    }

    public void AddScore(int score)
    {
        SoundControll.instance.PlayAddScore();

        Score += score;
        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }
    }

    public void OnRestart()
    {
        SoundControll.instance.PlayButton();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnLoadIntro()
    {
        SoundControll.instance.PlayButton();

        SceneManager.LoadScene("IntroScene");
    }


    public void ScrollSpeedUp()
    {
        currentSpeed += increaseSpeed;
    }
}
