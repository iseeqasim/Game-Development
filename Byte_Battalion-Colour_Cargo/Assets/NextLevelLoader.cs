using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextLevel;
    void Start()
    {
        nextLevel=SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        if (nextLevel == "Level-1")
        {
            nextLevel = "Level-2";
        }
        else if (nextLevel == "Level-2")
        {
            nextLevel = "Level-3";
        }
        else if (nextLevel == "Level-3")
        {
            nextLevel = "Level-4";
        }
        else if (nextLevel == "Level-4")
        {
            nextLevel = "Level-5";
        }
        else if (nextLevel == "Level-5")
        {
            nextLevel = "Level-6";
        }
        else if (nextLevel == "Level-6")
        {
            nextLevel = "Level-7";
        }
        else if (nextLevel == "Level-7")
        {
            nextLevel = "Level-8";
        }
        else if (nextLevel == "Level-8")
        {
            nextLevel = "Level-9";
        }
        else if (nextLevel == "Level-9")
        {
            nextLevel = "Level-10";
        }
        else if (nextLevel == "Level-10")
        {
            nextLevel = "Level-11";
        }
        else if (nextLevel == "Level-11")
        {
            nextLevel = "Level-12";
        }
        else if (nextLevel == "Level-12")
        {
            nextLevel = "MainMenu";
        }


        SceneManager.LoadScene(nextLevel);
    }
}
