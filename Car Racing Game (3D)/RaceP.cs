using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceP : MonoBehaviour
{
    public float speed = 25.0f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Vector3 carpos = transform.position;
        if (carpos.z >= 765f)
        {
            carpos.z = -160.13f;
            transform.position = carpos;
        }
    }
}
