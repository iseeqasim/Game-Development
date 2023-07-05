using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bus : MonoBehaviour
{
    public Text fuelText;
    public Text passengerText;
    float fuelval = 200;
    int maxPassengerCount = 30;
    int currentPassengerCount = 0;
    public GameObject students;
    public GameObject students2;
    public GameObject students3;
    int currentLoadIndex = 0;
    public Text healthText;
    public int health = 50;


    void Start()
    {
        UpdatePassengerText();
        healthText.text = "Health: " + health.ToString();
        UpdatePassengerText();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, .3f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -.3f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, .5f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -.5f, 0);
        }

        // Decrement fuel value only if the car is moving forward
        if (verticalInput > 0.0f)
        {
            fuelval -= Time.deltaTime * 5.0f;
        }

        // Update fuel text
        fuelText.text = "Fuel: " + Mathf.RoundToInt(fuelval).ToString();

        if (fuelval <= 0 || currentPassengerCount >= maxPassengerCount)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentLoadIndex == 0 && students.activeSelf && currentPassengerCount < maxPassengerCount)
            {
                currentPassengerCount += 10;
                students.SetActive(false);
                currentLoadIndex++;
                UpdatePassengerText();
            }
            else if (currentLoadIndex == 1 && students2.activeSelf && currentPassengerCount < maxPassengerCount)
            {
                currentPassengerCount += 10;
                students2.SetActive(false);
                currentLoadIndex++;
                UpdatePassengerText();
            }
            else if (currentLoadIndex == 2 && students3.activeSelf && currentPassengerCount < maxPassengerCount)
            {
                currentPassengerCount += 10;
                students3.SetActive(false);
                UpdatePassengerText();
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void UpdatePassengerText()
    {
        passengerText.text = "Seats: " + currentPassengerCount.ToString() + "/" + maxPassengerCount.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.name == "Traffic")
        {
            // Reduce health by 10
            health -= 2;
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            // Update health text
            healthText.text = "Health: " + health.ToString();
        }
    }


}
