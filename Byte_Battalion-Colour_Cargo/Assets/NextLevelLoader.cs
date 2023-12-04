using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextLevel;
    public string[] Levels =new string[11]{ "Level-2", "Level-3", "Level-4", "Level-5", "Level-6", "Level-7", "Level-8", "Level-9", "Level-10", "Level-11", "Level-12" };
    public bool isEndless;
    public int Endlesslevelnumber=13;

    public int GetEndlesslevelnumber()
    {
        return Endlesslevelnumber;
    }

    public bool GetisEndless()
    {
        return isEndless;
    }

    public void UpdateEndlessValues(bool newIsEndless, int newEndlessLevelNumber)
    {
        isEndless = newIsEndless;
        Endlesslevelnumber = newEndlessLevelNumber;
    }
    void Start()
    {
        nextLevel=SceneManager.GetActiveScene().name;
    }
    public void NextLevel()
    {
        if (!isEndless)
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
                int RandomLevel = Random.Range(0, 10);
                nextLevel = Levels[RandomLevel];
                Endlesslevelnumber = 13;
                isEndless=true;
                Debug.Log("NextLevel method called");
                Debug.Log(isEndless+" is the value of isendless in nextlevelloaderscript");
            }
        }
        else if(isEndless) 
        {
            int RandomLevel = Random.Range(0, 10);
            nextLevel = Levels[RandomLevel];
            Endlesslevelnumber++;
            Debug.Log("NextLevelNumber method called");
            Debug.Log(Endlesslevelnumber);
        }

        SceneManager.LoadScene(nextLevel);
    }
}
