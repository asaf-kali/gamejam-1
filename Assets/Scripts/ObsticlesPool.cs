﻿using UnityEngine;
using System.Collections;

public class ObsticlesPool : MonoBehaviour
{
    public int obsticlePoolSize;    // How many obsticles to keep on standby.
    public float spawnDelay;        // How quickly obsticles spawn.
    public float obsticleMin;       // Minimum x value of the obsticle position.
    public float obsticleMax;       // Maximum x value of the obsticle position.
    public GameObject original;

    private GameObject[] obsticles;                                   // Collection of pooled obsticles.
    private int currentColumn = 0;                                    // Index of the current obsticle in the collection.
    private Vector2 objectPoolPosition = new Vector2(-100, -100);       // A holding position for our unused obsticles offscreen.
    private float timeSinceLastSpawned;

    void Start()
    {
        timeSinceLastSpawned = 0f;

        // Initialize the obsticles collection.
        obsticles = new GameObject[obsticlePoolSize];
        // Loop through the collection... 
        for (int i = 0; i < obsticlePoolSize; i++)
        {
            // ...and create the individual obsticles.
            obsticles[i] = (GameObject)Instantiate(original, objectPoolPosition, original.transform.rotation, this.transform);
        }
    }

    // This spawns obsticles as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver || timeSinceLastSpawned < spawnDelay)
            return;

        Debug.Log("Sending new obsticle");
        timeSinceLastSpawned = 0f;

        // Set a random y position for the obsticle
        float spawnXPosition = Random.Range(obsticleMin, obsticleMax);

        GameObject newObsticle = obsticles[currentColumn];
        // ...then set the current obsticle to that position.
        newObsticle.transform.position = new Vector2(spawnXPosition, GameControl.instance.obsticlesSpawnY);
        Rigidbody2D rb = newObsticle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * GameControl.instance.speed;

        // Increase the value of currentColumn. If the new size is too big, set it back to zero
        currentColumn++;

        if (currentColumn >= obsticlePoolSize)
        {
            currentColumn = 0;
        }
    }
}