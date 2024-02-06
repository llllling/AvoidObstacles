using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private Vector2 moveDirection = Vector2.down;

    private Vector2 minMoveRange;
    private Vector2 maxMoveRange;

    private Player playerComponent;

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
        moveSpeed = 3f;
        moveDirection = Vector2.down;
    }

    void Start()
    {
        
        playerComponent = GetComponent<Player>();

        Tilemap background = FindFirstObjectByType<Tilemap>();
        float offsetX = background.size.x / 2f - GetComponent<CircleCollider2D>().radius - 0.3f;
        minMoveRange = new Vector2(-offsetX, 0);
        maxMoveRange = new Vector2(offsetX, transform.position.y);
    }

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover) return;
        Move();

        if (!IsStartPosition) { return; }
        if (!isStartWalkAnimation)
        {
            playerComponent.OnAnimationWalk();
            moveDirection = Vector2.left;
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

    private void Move()
    {
        transform.position = (Vector2)transform.position + moveSpeed * Time.deltaTime * moveDirection;
    }

    private void PositionWithinRange()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMoveRange.x, maxMoveRange.x), Mathf.Clamp(transform.position.y, minMoveRange.y, maxMoveRange.y));
    }
    private void ToggleDirection()
    {
        moveDirection = moveDirection == Vector2.left ? Vector2.right : Vector2.left;
        playerComponent.OnAnimationLeftRight(moveDirection);
    }


}
