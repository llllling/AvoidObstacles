using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Movement2D
{
    private void Start()
    {
        InitMovement(3f, Vector2.up);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(Player.PLAYER_TAG)) return;
   //     GameManager.instance.OnPlayerDead();
    }


}
