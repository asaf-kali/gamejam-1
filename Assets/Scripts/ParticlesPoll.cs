using UnityEngine;
using System.Collections;

public class ParticlesPoll : MonoBehaviour
{
    public float spawnDelay = 5f;
    public float xMin = -8f ;
    public float xMax = 8f;
    public float spawnYPosition = -10f;
    public float yVelocity = 5f;
    private float timeSinceLastSpawned;
    public GameObject original;

    void Start()
    {
        timeSinceLastSpawned = 0f;
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver || timeSinceLastSpawned < spawnDelay)
            return;
        timeSinceLastSpawned = 0f;
        CreateNewParticle();
    }

    void CreateNewParticle()
    {
        Debug.Log("Creating new particle");
        float spawnXPosition = Random.Range(xMin, xMax);
        Vector2 position = new Vector2(spawnXPosition, spawnYPosition);
        GameObject newParticle = Instantiate(original, position, original.transform.rotation, transform);
        Particle particle = newParticle.GetComponent<Particle>();
        particle.catchers.Add(GameControl.instance.player1);
        particle.catchers.Add(GameControl.instance.player2);
        Rigidbody2D rb = newParticle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * yVelocity;
    }
}