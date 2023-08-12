using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager4 : MonoBehaviour
{
    public GameObject firstMovingObject; // Reference to the first moving object
    public GameObject secondMovingObject; // Reference to the second moving object
    public GameObject thirdMovingObject; // Reference to the third moving object

    public float delayTime = 2f; // Delay time in seconds

    private bool firstObjectStartedMoving = false;
    private bool secondObjectStartedMoving = false;
    private bool thirdObjectStartedMoving = false;

    private bool delayStarted = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the first moving object has started moving
        if (!firstObjectStartedMoving && firstMovingObject != null && firstMovingObject.GetComponent<Train>().IsMovementStarted())
        {
            firstObjectStartedMoving = true;
        }

        // Check if the second moving object has started moving
        if (!secondObjectStartedMoving && secondMovingObject != null && secondMovingObject.GetComponent<Train>().IsMovementStarted())
        {
            secondObjectStartedMoving = true;
        }

        // Check if the third moving object has started moving
        if (!thirdObjectStartedMoving && thirdMovingObject != null && thirdMovingObject.GetComponent<Train>().IsMovementStarted())
        {
            thirdObjectStartedMoving = true;
        }

        // Check if all objects have started moving
        if (firstObjectStartedMoving && secondObjectStartedMoving && thirdObjectStartedMoving && !delayStarted)
        {
            // Start the delay timer
            delayStarted = true;
            StartCoroutine(DelayAndLoadScene());
        }
    }

    // Coroutine for delaying and loading the scene
    private IEnumerator DelayAndLoadScene()
    {
        yield return new WaitForSeconds(delayTime);

        // Load the "MainMenu" scene
        SceneManager.LoadScene("MainMenu");
    }
}
