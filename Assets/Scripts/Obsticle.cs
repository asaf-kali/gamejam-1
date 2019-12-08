using UnityEngine;
using System.Collections;

public class Obsticle : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameControl.instance.ball.GetComponent<CircleCollider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            // If the bird hits the trigger collider in between the columns then
            // tell the game control that the bird scored.
            GameControl.instance.BallPass();
        }
    }
}
