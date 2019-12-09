using UnityEngine;


public class RepeatingBackground : MonoBehaviour
{
    // This stores a reference to the collider attached to the Background.
    private BoxCollider2D bgCollider;
     
    // A float to store the y-axis length of the collider2D attached to the Background GameObject.
    private float bgVerticalLength;

    // Awake is called before Start.
    private void Awake()
    {
        // Get and store a reference to the collider2D attached to Background.
        bgCollider = GetComponent<BoxCollider2D>();

        // Store the size of the collider along the y-axis (its length in units).
        bgVerticalLength = bgCollider.size.y;
    }

    // Update runs once per frame
    private void Update()
    {
        // Check if the difference along the y axis between the main Camera and
        //the position of the object this is attached to is greater than bgVerticalLength.
        if (transform.position.y > bgVerticalLength)
        {
            // If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground();
        }
    }

    // Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        // This is how far to below we will move our background object, in this case, twice its length.
        //This will position it directly below of the currently visible background object.
        Vector2 groundOffSet = new Vector2(0, bgVerticalLength * -2f);

        // Move this object from it's position offscreen, behind the player, to the new position off-camera
        //in front of the player.
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}