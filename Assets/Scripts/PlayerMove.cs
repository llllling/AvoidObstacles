using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : Movement2D
{

    private Vector2 currentDirection = Vector2.left;
    private Vector2 minMoveRange;
    private Vector2 maxMoveRange;
    
    private Animator animator;

    private bool isStartWalkAnimation = false;
    private bool IsStartPosition
    {
        get
        {
            if (transform.position.y > minMoveRange.y) return false;
            return true;
        }
    }


    void Reset()
    {
        InitMovement(3f, Vector2.down);
    }

    void Start()
    {
        Tilemap background = FindFirstObjectByType<Tilemap>();
        float offsetX = background.size.x / 2f - GetComponent<CircleCollider2D>().radius - 0.3f;
        minMoveRange = new Vector2(-offsetX, 0);
        maxMoveRange = new Vector2(offsetX, transform.position.y);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.IsGameover) return;

        Move();

        if (!IsStartPosition) { return; }
        if (!isStartWalkAnimation)
        {
            animator.SetTrigger("Walk");
            isStartWalkAnimation = true;
        }

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            ToggleDirection();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ToggleDirection();
            }
        }
#endif

    }

    void LateUpdate()
    {
        PositionWithinRange();
    }

    private void PositionWithinRange()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMoveRange.x, maxMoveRange.x), Mathf.Clamp(transform.position.y, minMoveRange.y, maxMoveRange.y));
    }
    private void ToggleDirection()
    {
        currentDirection = currentDirection == Vector2.left ? Vector2.right : Vector2.left;
        ExecuteAnimation(currentDirection);
        MoveTo(currentDirection);
    }

    private void ExecuteAnimation(Vector2 currentDirection)
    {
        if (currentDirection == Vector2.right)
        {
            animator.SetBool("IsLeft", false);
        } else if (currentDirection == Vector2.left)
        {
            animator.SetBool("IsLeft", true);
        }
    }
}
