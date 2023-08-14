using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject gameoverpanel; // Reference to the gameover panel

    public AudioSource newBackgroundMusic;
    public GameObject explosionParticlePrefab;


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
                // Get the number of available cargos in the train
                int availableCargos = train.GetNextAvailableCargoIndex();

                // Call the Deactivatetwocargos function in the Train class
                train.Deactivatetwocargos();

                // Check if the train has one or zero cargo
                if (availableCargos <= 1)
                {
                    // Set the gameover panel active
                    Time.timeScale = 0;

                    AudioSource previousBackgroundMusic = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
                    if (previousBackgroundMusic != null)
                    {
                        previousBackgroundMusic.Stop();
                    }

                    // Play the new background music
                    if (newBackgroundMusic != null)
                    {
                        newBackgroundMusic.Play();
                    }


                    gameoverpanel.SetActive(true);
                }
            }

            // Destroy the bomb after collision with a train
            if (explosionParticlePrefab != null)
            {
                Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
