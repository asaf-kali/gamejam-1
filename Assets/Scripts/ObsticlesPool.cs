using UnityEngine;
using System.Collections;

public class ObsticlesPool : MonoBehaviour
{
    public int obsticlePoolSize = 4;                                  // How many obsticles to keep on standby.
    public float spawnRate = 4f;
    //public float spawnDelay = 3f;                                     // How quickly obsticles spawn.
    public float obsticleMin = -8f;                                   // Minimum x value of the obsticle position.
    public float obsticleMax = 8f;                                    // Maximum x value of the obsticle position.
    public float spawnYPosition = -10f;
    //public float yVelocity = 7f;

    public GameObject BadObstical1;
    public GameObject BadObstical2;
    public GameObject GoodObstical1;
    public GameObject GoodObstical2;


    private GameObject[] obsticles;                                     // Collection of pooled obsticles.
    //private int currentObstical = 0;                                    // Index of the current obsticle in the collection.
    private Vector2 obsticalPoolPosition = new Vector2(-15, -25);       // A holding position for our unused obsticles offscreen.
    private float timeSinceLastSpawned;


    void Start()
    {
        //    timeSinceLastSpawned = 0f;

        // Initialize the obsticles collection.
        obsticles = new GameObject[obsticlePoolSize];

        // Loop through the collection... 
        //for (int i = 0; i < obsticlePoolSize; i++)
        //{
        //    obsticles[i] = (GameObject)Instantiate(obsticalPrefab,
        //    obsticalPoolPosition, Quaternion.identity);
        //}


        obsticles[0] = (GameObject)Instantiate(BadObstical1,
            obsticalPoolPosition, BadObstical1.transform.rotation, this.transform);
        obsticles[1] = (GameObject)Instantiate(BadObstical2,
            obsticalPoolPosition, BadObstical2.transform.rotation, this.transform);
        obsticles[2] = (GameObject)Instantiate(GoodObstical1,
            obsticalPoolPosition, GoodObstical1.transform.rotation, this.transform);
        obsticles[3] = (GameObject)Instantiate(GoodObstical2,
            obsticalPoolPosition, GoodObstical2.transform.rotation, this.transform);
    }


    // This spawns obsticles as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver || timeSinceLastSpawned < spawnRate)
        {
            return;
        }

        Debug.Log("Sending new obsticle");
        timeSinceLastSpawned = 0f;

        // Set a random x position for the obsticle
        float spawnXPosition = Random.Range(obsticleMin, obsticleMax);

        obsticles[Random.Range(0, 3)].transform.position = new Vector2(spawnXPosition, spawnYPosition);


    //    GameObject newObsticle = obsticles[currentColumn];
    //    // ...then set the current obsticle to that position.
    //    newObsticle.transform.position = new Vector2(spawnXPosition, spawnYPosition);
    //    Rigidbody2D rb = newObsticle.GetComponent<Rigidbody2D>();
    //    rb.velocity = Vector3.up * yVelocity;

    //    // Increase the value of currentColumn. If the new size is too big, set it back to zero
        //currentObstical++;

        //if (currentObstical >= obsticlePoolSize)
        //{
        //    currentObstical = 0;
        //}
    }
}