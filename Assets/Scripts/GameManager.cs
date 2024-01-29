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
        } else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�.");
            Destroy(gameObject);
        }
        
    }

    public void OnPlayerDead()
    {
        IsGameover = true;
        gameOverObj.SetActive(true);

    }

    public void AddScore(int score)
    {
        Score += score;
        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }
    }

    public void OnRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnLoadIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
