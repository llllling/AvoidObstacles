using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text lastScoreText;
    public GameObject gameOverObj;

    void Start()
    {
        scoreText.gameObject.SetActive(true);
    }
    void Update()
    {
        if (GameManager.Instance.IsGameover)
        {
            if (gameOverObj.activeSelf) return;
            OnPlayerDeadUI();
        }
        else
        {
            ScoreUI();
        }
    }
    public void OnPlayerDeadUI()
    {
        lastScoreText.text = scoreText.text.ToString();
        scoreText.gameObject.SetActive(false);
        gameOverObj.SetActive(true);
    }
    public void ScoreUI()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
    }
}
