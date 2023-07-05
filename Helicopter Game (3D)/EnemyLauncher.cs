using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 9; i++)
        {
            Vector3 enemypos = new Vector3(Random.Range(500, 1000), Random.Range(30, 50), Random.Range(80, 200));
            Instantiate(enemy, enemypos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}