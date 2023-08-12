using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        // Move the bomb vertically along the tracks
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Train"))
        {
            // Check if the collided object has a Train component
            Train train = collision.gameObject.GetComponent<Train>();
            if (train != null)
            {
                // Call the Deactivatetwocargos function in the Train class
                train.Deactivatetwocargos();
            }

            // Destroy the bomb after collision with a train
            Destroy(gameObject);
        }
    }
}
