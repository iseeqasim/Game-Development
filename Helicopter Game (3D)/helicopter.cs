using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopter : MonoBehaviour
{
    public GameObject Bullet;

    // Update is called once per frame
    void Update()
    {
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 40f * Time.deltaTime);
        }

        // Move backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 30f * Time.deltaTime);
        }

        // Turn left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -20f * Time.deltaTime);
        }

        // Turn right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 20f * Time.deltaTime);
        }

        // Move up
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 10f * Time.deltaTime);
        }

        // Move down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * 10f * Time.deltaTime);
        }

        // Move left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * 10f * Time.deltaTime);
        }

        // Move right
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * 10f * Time.deltaTime);
        }

        // Yaw left
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.forward, 15f * Time.deltaTime);
        }

        // Yaw right
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.forward, -15f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Vector3 heliposition = transform.position;
            heliposition.y -= 2f;
            Instantiate(Bullet, heliposition, transform.rotation);
        }
    }
}
