using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector2 moveDirection = Vector2.zero;
    public void Update()
    {
        Move();
    }
    public void Move()
    {
       transform.position = (Vector2)transform.position + moveSpeed * Time.deltaTime * moveDirection;
    }
  
    public void InitMovement(float initSpeed, Vector2 initDirection)
    {
        moveSpeed = initSpeed;
        moveDirection = initDirection;
    }

    public void MoveTo(Vector2 direction)
    {
        moveDirection = direction;
    }

    public void Speed(float speed)
    {
        moveSpeed = speed;
    }
}
