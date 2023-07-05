using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))//forward
        {
            transform.Translate(0, 0, 1f);
        }

        if (Input.GetKey(KeyCode.DownArrow))//Backward
        {
            transform.Translate(0, 0, -1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))//Right
        {
            transform.Rotate(0, 1f, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))//Left
        {
            transform.Rotate(0, -1f, 0);
        }

        if (Input.GetKey(KeyCode.U))//upwards
        {
            transform.Translate(0, 1f, 0);
        }

        if (Input.GetKey(KeyCode.D))//Downwards
        {
            transform.Translate(0, -1f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))//Instantiate Bullet
        {
            Vector3 heliposition = transform.position;
            heliposition.y -= 2f;
            Instantiate(bullet, heliposition, transform.rotation);
        }


    }
}
