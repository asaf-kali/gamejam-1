using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forgivenessTime;
    private float timeSinceHit = 0f;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        timeSinceHit += Time.deltaTime;
        transform.position = GameControl.instance.KeepInMap(transform.position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(this.name + " collided with " + other.gameObject.name);
        if (other.gameObject == GameControl.instance.ball)
        {
            GameControl.instance.BallPass();
        }
        else if (other.gameObject.GetComponent<Player>() != null)
        {
            return;
        }
        else
        {
            // Obsticle hit
            if (timeSinceHit <= forgivenessTime)
            {
                Debug.Log("Saved because of spare time " + timeSinceHit + " is not yet " + forgivenessTime);
                return;
            }
            Debug.Log("Hit!");
            timeSinceHit = 0;
            Particle[] particles = GetComponentsInChildren<Particle>(true);
            if (particles.Length == 0)
            {
                GameControl.instance.GameOver();
                return;
            }
            particles[0].Detach();
        }
    }
}