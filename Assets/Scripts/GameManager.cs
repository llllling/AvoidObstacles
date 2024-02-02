using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    public GameObject gameOverObj;

    public AudioClip buttonSound;
    public AudioClip dieSound;
    public AudioClip addScoreSound;
    private AudioSource audioSource;

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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPlayerDead()
    {
        audioSource.PlayOneShot(dieSound);

        scoreText.gameObject.SetActive(false);

        gameOverObj.transform.Find("LastScore").transform.GetChild(0).GetComponent<TMP_Text>().text = scoreText.text;
        
        IsGameover = true;
        
        gameOverObj.SetActive(true);

    }

    public void AddScore(int score)
    {
        audioSource.PlayOneShot(addScoreSound);

        Score += score;
        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }
    }

    public void OnRestart() {
        audioSource.PlayOneShot(buttonSound);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnLoadIntro()
    {
        audioSource.PlayOneShot(buttonSound);

        SceneManager.LoadScene("IntroScene");
    }
}
