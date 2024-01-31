using UnityEngine;

public class Coin : MovementSpeedUP
{
    [SerializeField]
    private int coinScore = 10;
    
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag(Player.playerTag)) return;
        gameObject.SetActive(false);
        GameManager.instance.AddScore(coinScore);
    }
}
