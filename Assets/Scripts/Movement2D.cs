using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector2 moveDirection = Vector2.zero;
    void Update()
    {
        if (GameManager.instance.IsGameover) return;
        Move();
    }
    protected void InitMovement(float speed, Vector2 direction)
    {
        moveSpeed = speed;
        moveDirection = direction;
    }

    protected void Move()
    {
        transform.position = (Vector2)transform.position + moveSpeed * Time.deltaTime * moveDirection;
    }

    protected void MoveTo(Vector2 direction)
    {
        moveDirection = direction;
    }

    protected void Speed(float speed)
    {
        moveSpeed = speed;
    }
}
