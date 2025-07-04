using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // Speed of the scrolling object
    // Start is called once

    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.instance.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
            }
}
