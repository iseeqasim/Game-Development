using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public GameObject firstMovingObject; // Reference to the first moving object
    public GameObject secondMovingObject; // Reference to the second moving object

    public float delayTime = 2f; // Delay time in seconds

    private bool firstObjectStartedMoving = false;
    private bool secondObjectStartedMoving = false;
    private bool delayStarted = false;

    public GameObject levelWinPanel;

    private float bestTime=Mathf.Infinity;
    public Text guiText;
    public Text guiText2;

    // Update is called once per frame
    void Start()
    {
        levelWinPanel.SetActive(false);
    }
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

        // Check if both objects have started moving
        if (firstObjectStartedMoving && secondObjectStartedMoving && !delayStarted)
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
        
        // Calculate the current level completion time
        float currentTime = float.Parse(guiText.text);
        float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);

        // Compare with the best time
        if (currentTime < bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); // Save the best time

            // Load the "MainMenu" scene
            
        }
        levelWinPanel.SetActive(true);
    }
}
