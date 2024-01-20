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
        if (transform.position.y >= backgroundSize.height)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        transform.position = (Vector2)transform.position - new Vector2(0, backgroundSize.height * 2f);
    }
}
