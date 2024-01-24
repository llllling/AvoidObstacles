using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsGameover { get; private set; } = false;
    public int Score { get; private set; } = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
        
    }

    public void OnPlayerDead()
    {
        IsGameover = true;
    }

    public void AddScore(int score)
    {
        Score += score;
    }
}
