using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;
    public float enemySpeed = 2f;
    public float spawnInterval = 4f;
    public float destroyDelay = 2f;

    private GameObject currentEnemy;
    private bool canSpawn = true;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        if (canSpawn && currentEnemy == null)
        {
            canSpawn = false;
            Invoke("SpawnEnemy", spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
        EnemyMovement enemyMovement = currentEnemy.GetComponent<EnemyMovement>();
        enemyMovement.speed = enemySpeed;
        enemyMovement.destroyDelay = destroyDelay;

        currentEnemy.GetComponent<EnemyCollision>().bulletPrefab = bulletPrefab;
        currentEnemy.GetComponent<EnemyCollision>().destroyDelay = destroyDelay;

        canSpawn = true;
    }

    private Vector3 GetRandomPosition()
    {
        float xPos = Random.Range(-10f, 10f);
        float yPos = Random.Range(-5f, 5f);
        return new Vector3(xPos, yPos, 0f);
    }
}
