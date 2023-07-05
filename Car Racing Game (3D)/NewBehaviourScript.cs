using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Race;
    public Vector3 offset;

    public void Start()
    {
        offset = transform.position - Race.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Race.transform.position + offset;
        transform.LookAt(Race.transform.position);
    }
}