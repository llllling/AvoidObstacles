using UnityEngine;

public enum ItemType
{
    Invincible
}
public abstract class Item : Movement2D
{
    public abstract void Use();

    void Reset()
    {
        InitMovement(3f, Vector2.up);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Player.playerTag)) return;
        gameObject.SetActive(false);
       
        Use();
    }

}
