using System.Collections;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    public GameObject cubePrefab;
    public float minSpawnInterval = 4f; // Minimum time interval between cube spawns
    public float maxSpawnInterval = 7f; // Maximum time interval between cube spawns

    private void Start()
    {
        // Start spawning cubes
        StartCoroutine(SpawnCubes());
    }

    private void SpawnCube()
    {
        // Instantiate a new cube at the spawner's position
        GameObject newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            // Spawn a new cube
            SpawnCube();

            // Randomize the spawn interval between minSpawnInterval and maxSpawnInterval
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Wait for the random interval before spawning the next cube
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
