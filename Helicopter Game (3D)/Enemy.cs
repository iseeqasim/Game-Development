using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject heli;
    public GameObject explosionPrefab; // Drag and drop the explosion prefab here in the inspector
    private float explosionTimer = 5f; // Timer for explosion

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.2f);
        transform.LookAt(heli.transform);

        // Decrement the explosion timer by the time elapsed since last frame
        explosionTimer -= Time.deltaTime;

        // If the explosion timer has reached zero, create the explosion and destroy the enemy object
        if (explosionTimer <= 0f)
        {
            // Create the explosion
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Destroy the enemy object
            Destroy(gameObject);
        }
    }
}
