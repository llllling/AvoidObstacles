using System.Collections;
using UnityEngine;

public enum ItemType
{
    Invincible
}
public abstract class Item : MovementSpeedUP
{
    public abstract void Use();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Player.playerTag)) return;

        gameObject.SetActive(false);
        Use();
    }
}
