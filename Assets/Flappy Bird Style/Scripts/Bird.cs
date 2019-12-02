using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    public float upForce;                   // Upward force of the "flap".
    private bool isDead = false;            // Has the player collided with a wall?

    private Animator anim;                  // Reference to the Animator component.
    private Rigidbody2D rb;               // Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        // Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        // Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb = GetComponent<Rigidbody2D>();
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
            // TODO: Add points;
        }
        // else if (other.gameObject == ) // Other bird
        // {

        // }
        else
        {
            // Zero out the bird's velocity
            rb.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            anim.SetTrigger("Die");
            //...and tell the game control about it.
            GameControl.instance.BirdDied();
        }
    }
}
