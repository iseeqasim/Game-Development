using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroChecker : MonoBehaviour
{
    public bool isEndlessLevel;
    public GameObject endlessPanel;
    public GameObject regularPanel;
    public NextLevelLoader nll;

    void Start()
    {
        nll = GameObject.FindObjectOfType<NextLevelLoader>();
        // Get a reference to the other script on the same GameObject
        //NextLevelLoader otherScript = GetComponent<NextLevelLoader>();

        // Check the isEndless variable from the other script
        isEndlessLevel = nll.GetisEndless();
        Debug.Log("IntroChecker Start method called");
        Debug.Log(nll.isEndless+ " is the value of isendless in intro checker script");
        // Set the active panel based on the isEndless variable
        if (nll.GetisEndless())
        {
            endlessPanel.SetActive(true);
            regularPanel.SetActive(false);
        }
        else
        {
            endlessPanel.SetActive(false);
            regularPanel.SetActive(true);
        }
    }
    void Update()
    { 
    
    }

}
