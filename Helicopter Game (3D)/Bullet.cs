using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1f);

    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name.StartsWith("Enemy"))
        {
            print("col");
            Destroy(col.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

        Destroy(transform.gameObject);
    }
}