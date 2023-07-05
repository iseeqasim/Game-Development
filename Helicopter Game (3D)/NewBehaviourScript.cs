using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Helicopter;
    public Vector3 offset;

    public void Start()
    {
        offset = transform.position - Helicopter.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Helicopter.transform.position + offset;
        transform.LookAt(Helicopter.transform.position);
    }
}