using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, GameControl.scrollSpeed);
    }

    private void Update()
    {
        if (GameControl.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
