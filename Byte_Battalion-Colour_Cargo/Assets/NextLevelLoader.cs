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
        if (nextLevel == "Tutorial")
        {
            nextLevel = "Level1";
        }
        else if (nextLevel == "Level1")
        {
            nextLevel = "Level2";
        }
        else if (nextLevel == "Level2")
        {
            nextLevel = "Level3";
        }
        else if (nextLevel == "Level3")
        {
            nextLevel = "Level4";
        }
        else if (nextLevel == "Level4")
        {
            nextLevel = "Level5";
        }
        else if (nextLevel == "Level5")
        {
            nextLevel = "Level6";
        }
        else if (nextLevel == "Level6")
        {
            nextLevel = "MainMenu";
        }


        SceneManager.LoadScene(nextLevel);
    }
}
