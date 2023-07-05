using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaScript : MonoBehaviour
{

    public Vector3 offset;
    public GameObject Heli;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Heli.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=offset + Heli.transform.position;
    }
}
