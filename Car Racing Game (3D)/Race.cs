using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Race : MonoBehaviour
{
    public float speed = 50.0f;
    public float rotationSpeed = 100.0f;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    public AudioSource horn;
    public Text fuelText;
    float fuelval = 150;

    // Declare a variable to hold the nitro boost amount
    public float nitroBoost = 20.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fuelText.text = "Fuel: " + fuelval.ToString();
        horn = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (fuelval <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        if (Input.GetKey(KeyCode.H))
        {
            horn.Play();
        }

        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply nitro boost to the car's speed
            speed += nitroBoost;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 carpos = transform.position;
        if (carpos.z >= 765.3f)
        {
            carpos.z = -174.1f;
            transform.position = carpos;
        }

        // Decrement fuel value only if the car is moving forward
        if (verticalInput > 0.0f)
        {
            fuelval -= Time.deltaTime * 5.0f;
        }

        // Update fuel text
        fuelText.text = "Fuel: " + Mathf.RoundToInt(fuelval).ToString();

        if (fuelval <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }


        if (fuelval <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

    }


    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed * verticalInput);
        rb.MoveRotation(transform.rotation * Quaternion.Euler(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput));
    }
}
