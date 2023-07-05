using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleC : MonoBehaviour
{
    public GameObject apple;
    private Vector2 applepos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            applepos = new Vector2(Random.Range(0, 56), Random.Range(0.5f, 2));
            Instantiate(apple, applepos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
