using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
     bool IsStartPosition
    {
        get
        {
            if (transform.position.y > 0) return false;
            return true;
        }
    }

    Vector2 currentDirection = Vector2.left;

    [SerializeField]
    private float speedForXAxis = 3f;


    void Start()
    {

    }

    // Update is called once per frame
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
        MovePosition(speedForXAxis, currentDirection);
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
