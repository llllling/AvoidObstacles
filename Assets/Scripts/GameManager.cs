using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    public GameObject gameOverObj;



    public bool IsGameover { get; private set; } = false;
    public int Score { get; private set; } = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
        
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

    public void OnRestart() {
        SoundControll.instance.PlayButton();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnLoadIntro()
    {
        SoundControll.instance.PlayButton();

        SceneManager.LoadScene("IntroScene");
    }
}
