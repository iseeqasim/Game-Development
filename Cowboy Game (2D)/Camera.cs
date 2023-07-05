using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public GameObject Cowboy;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Cowboy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Cowboy.transform.position + offset;
    }
}
