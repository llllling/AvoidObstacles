using UnityEngine;

public class Coin : Movement2D
{
    [SerializeField]
    private int coinScore = 10;
    void Reset()
    {
        InitMovement(3f, Vector2.up);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag(Player.PLAYER_TAG)) return;
        gameObject.SetActive(false);
        GameManager.instance.AddScore(coinScore);
    }
}
