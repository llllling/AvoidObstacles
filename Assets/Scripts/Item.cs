using UnityEngine;

public enum ItemType
{
    Invincible
}
public abstract class Item : MovementSpeedUP
{
    public AudioClip collisionSound;
    private AudioSource audioSource;
    public abstract void Use();

    void Start()
    {
        InitMovementSpeedUP();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Player.playerTag)) return;
        
        audioSource.PlayOneShot(collisionSound);

        gameObject.SetActive(false);

        Use();
    }

}
