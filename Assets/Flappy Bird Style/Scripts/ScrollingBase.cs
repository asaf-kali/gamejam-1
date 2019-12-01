using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBase : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected float movingSpeed;

    public ScrollingBase(float movingSpeed)
    {
        this.movingSpeed = movingSpeed;
    }
    // Use this for initialization
    void Start()
    {
        // Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        // Start the object moving.
        rb2d.velocity = new Vector2(movingSpeed, 0);
    }

    void Update()
    {
        // If the game is over, stop scrolling.
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
