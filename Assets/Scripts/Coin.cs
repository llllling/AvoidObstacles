using UnityEngine;

public class Coin : MovementSpeedUP
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    [SerializeField]
    private int coinScore = 10;

    void Start()
    {
        InitMovementSpeedUP();
        audioSource = GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag(Player.playerTag)) return;
        audioSource.PlayOneShot(collisionSound);
        
        GameManager.instance.AddScore(coinScore);

        gameObject.SetActive(false);
        
    }
}
