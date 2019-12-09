using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * GameControl.instance.speed;
    }

    private void Update()
    {
        if (GameControl.instance.gameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
