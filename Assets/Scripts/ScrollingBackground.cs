using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, GameControl.instance.scrollSpeed);
    }

    private void Update()
    {
        if (GameControl.instance.gameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
