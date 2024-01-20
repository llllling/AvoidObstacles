using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public struct Size
    {
        public float width;
        public float height;
    }
    public Size backgroundSize;

    void Start()
    {
       Vector2 colliderSize = GetComponent<BoxCollider2D>().size;
        backgroundSize.width = colliderSize.x;
        backgroundSize.height = colliderSize.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= backgroundSize.width)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        transform.position = (Vector2)transform.position - new Vector2(0, height * 2f);
    }
}
