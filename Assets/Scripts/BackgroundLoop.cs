using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float height;

    void Start()
    {
        height = GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameover) return;

        if (transform.position.y >= height)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        transform.position = (Vector2)transform.position - new Vector2(0, height * 2f);
    }
}
