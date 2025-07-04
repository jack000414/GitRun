using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width; // Width of the background
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}
