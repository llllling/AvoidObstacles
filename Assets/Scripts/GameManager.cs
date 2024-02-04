using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    public GameObject gameOverObj;

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
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
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
