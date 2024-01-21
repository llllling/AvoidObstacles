using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 moveDirection = Vector2.zero;

   
    public void Update()
    {
        transform.position = (Vector2)transform.position + speed * Time.deltaTime * moveDirection;
    }

    public void Init(float initSpeed, Vector2 initDirection)
    {
        speed = initSpeed;
        moveDirection = initDirection;
    }

    public void MoveTo(Vector2 direction)
    {
        moveDirection = direction;
    }

}
