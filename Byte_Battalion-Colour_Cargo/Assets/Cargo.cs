using System.Collections;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject secondCubePrefab; // The second cube prefab to be spawned less frequently
    public float minSpawnInterval = 4f; // Minimum time interval between cube spawns
    public float maxSpawnInterval = 7f; // Maximum time interval between cube spawns
    public float startTimeForRandomSpawn = 30f; // Time after which random spawn starts

    private bool isRandomSpawnEnabled = false;

    private void Start()
    {
        // Start spawning cubes
        StartCoroutine(SpawnCubes());
    }

    private void Update()
    {
        // Enable random spawn after the specified start time
        if (!isRandomSpawnEnabled && Time.time >= startTimeForRandomSpawn)
        {
            isRandomSpawnEnabled = true;
        }
    }

    private void SpawnCube()
    {
        GameObject prefabToSpawn;

        if (isRandomSpawnEnabled && Random.value < 0.4f)
        {
            prefabToSpawn = secondCubePrefab;
        }
        else
        {
            prefabToSpawn = cubePrefab;
        }

        // Instantiate a new cube at the spawner's position
        GameObject newCube = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
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
