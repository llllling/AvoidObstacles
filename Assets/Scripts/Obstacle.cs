using UnityEngine;

public class Obstacle : Movement2D
{
    private void Start()
    {
        InitMovement(3f, Vector2.up);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(Player.playerTag)) return;
     //   GameManager.instance.OnPlayerDead();

        if(Player.status == PlayerStatus.INVINCIBLE)
        {

        }
      
    }


}
