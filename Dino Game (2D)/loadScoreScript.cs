using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadScoreScript : MonoBehaviour
{
    public Text text;
    float currentScore;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetFloat("healthvalue");
        text.text = "Health: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void closeGame()
    {
        Application.Quit();
    }
}