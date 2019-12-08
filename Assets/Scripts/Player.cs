using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float upForce;                   // Upward force of the "flap".
    public bool isDead = false;            // Has the player collided with a wall?
    public Animator anim;                  // Reference to the Animator component.
    public Rigidbody2D rb;               // Holds a reference to the Rigidbody2D component of the bird.

    protected void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        // Don't allow control if the bird has died.
        if (isDead)
        {
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(this.name + " collided with " + other.gameObject.name);
        if (other.gameObject == GameControl.instance.ball)
        {
            GameControl.instance.BallPass();
            // GameControl.instance.ball.GetComponent<Rigidbody2D>().velocity *= -2f;
        }
        else
        {
            // rb.velocity = Vector2.zero;
            isDead = true;
            // GameControl.instance.GameOver();
        }
    }
}