using System.Collections;
using UnityEngine;

public class Obstacle : MovementSpeedUP
{
    private Animator animator;
    private new Rigidbody2D rigidbody;
    private const float forceMagnitude = 15f;


    void Start()
    {
        InitMovement(3f, Vector2.up);
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(Player.playerTag)) return;


        if (Player.status == PlayerStatus.INVINCIBLE)
        {

            StartCoroutine(BouncesOff());
            return;
        }

        //   GameManager.instance.OnPlayerDead();



    }

    private IEnumerator BouncesOff()
    {
        animator.enabled = true;

        rigidbody.constraints = RigidbodyConstraints2D.None;

        Vector2 forceDirection = new(1f, 1f);
        if (transform.position.x < 0)
        {
            forceDirection = new(-1f, 1f);
        }
        rigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);

        animator.enabled = false;

        rigidbody.velocity = Vector2.zero;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.rotation = Quaternion.identity;
    }
}
