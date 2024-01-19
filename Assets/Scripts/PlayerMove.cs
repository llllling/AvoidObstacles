using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    Vector2 currentDirection = Vector2.left;

    [SerializeField]
    private float moveSpeed = 3f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0) {
            transform
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
        transform.position = (Vector2)transform.position + moveSpeed * Time.deltaTime * currentDirection;
    }
    private void movePosition(float speed, Vector2 direction)
    {
        transform.position = (Vector2)transform.position + moveSpeed * Time.deltaTime * direction;
    }
    private Vector2 ToggleDirection()
    {
       currentDirection = currentDirection == Vector2.left ? Vector2.right : Vector2.left;
        return currentDirection;
    }
}
