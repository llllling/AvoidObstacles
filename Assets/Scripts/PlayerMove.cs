using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float speedForXAxis = 3f;

    Vector2 currentDirection = Vector2.left;
    float minMoveRangeX;
    float maxMoveRangeX;
    bool IsStartPosition
    {
        get
        {
            if (transform.position.y > 0) return false;
            return true;
        }
    }

    bool IsMoveValidityCheck
    {
        get
        {
            if (currentDirection == Vector2.left && transform.position.x <= minMoveRangeX
                || currentDirection == Vector2.right && transform.position.x >= maxMoveRangeX)
            {
                return false;
            }
            return true;
        }
    }

    private void Start()
    {
        var background = FindFirstObjectByType<Tilemap>();
        Debug.Log(GetComponent<CircleCollider2D>().radius);
        float offset = background.size.x / 2f - GetComponent<CircleCollider2D>().radius - 0.3f;
        minMoveRangeX = background.transform.position.x - offset;
        maxMoveRangeX = background.transform.position.x + offset;
    }

    void Update()
    {
        if (!IsStartPosition) {
            MoveStartPosition();
            return;
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
        if (IsMoveValidityCheck)
        {
            MovePosition(speedForXAxis, currentDirection);
        }
    }
    private void MoveStartPosition() {
        MovePosition(3f, Vector2.down);
    }

    private void MovePosition(float speed, Vector2 direction)
    {
        transform.position = (Vector2)transform.position + speed * Time.deltaTime * direction;
    }
    
    private Vector2 ToggleDirection()
    {
       currentDirection = currentDirection == Vector2.left ? Vector2.right : Vector2.left;
        return currentDirection;
    }
}
