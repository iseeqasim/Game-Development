using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countup : MonoBehaviour
{
    double Timer = 0.0;
    public Text guiText;
    public Text guiText2;
    public string nextLevel;
    public WinManager winM;
    public WinManager4 winM4;

    
    
    // Start is called before the first frame update
    void Start()
    {
        nextLevel=SceneManager.GetActiveScene().name;
        if (nextLevel == "Tutorial")
        {
            float bestTime = PlayerPrefs.GetFloat("BestTimeTutorial", Mathf.Infinity);
            if (bestTime == Mathf.Infinity)
            {
                guiText2.text = "NA";
            }
            else
            {
                guiText2.text = bestTime.ToString();
            }
        }
        else if (nextLevel == "Level1")
        {
            float bestTime = PlayerPrefs.GetFloat("BestTimeLevel1", Mathf.Infinity);
            if (bestTime == Mathf.Infinity)
            {
                guiText2.text = "NA";
            }
            else
            {
                guiText2.text = bestTime.ToString();
            }
        }
        else if (nextLevel == "Level2")
        {
            float bestTime = PlayerPrefs.GetFloat("BestTimeLevel2", Mathf.Infinity);
            if (bestTime == Mathf.Infinity)
            {
                guiText2.text = "NA";
            }
            else
            {
                guiText2.text = bestTime.ToString();
            }
        }
        else if (nextLevel == "Level3")
        {
            float bestTime = PlayerPrefs.GetFloat("BestTimeLevel3", Mathf.Infinity);
            if (bestTime == Mathf.Infinity)
            {
                guiText2.text = "NA";
            }
            else
            {
                guiText2.text = bestTime.ToString();
            }
        }
        else if (nextLevel == "Level4")
        {
            float bestTime = PlayerPrefs.GetFloat("BestTimeLevel4", Mathf.Infinity);
            if (bestTime == Mathf.Infinity)
            {
                guiText2.text = "NA";
            }
            else
            {
                guiText2.text = bestTime.ToString();
            }
        }
        else if (nextLevel == "Level5")
        {
            float bestTime = PlayerPrefs.GetFloat("BestTimeLevel5", Mathf.Infinity);
            if (bestTime == Mathf.Infinity)
            {
                guiText2.text = "NA";
            }
            else
            {
                guiText2.text = bestTime.ToString();
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextLevel == "Level4" || nextLevel == "Level5")
        {
            if (!winM4.timestop)
            {
                Timer += Time.deltaTime;
                int seconds = ((int)Timer);
                guiText.text = "" + seconds;
            }
        }
        else if (!winM.timestop) {
            Timer += Time.deltaTime;
            int seconds = ((int)Timer);
            guiText.text = "" + seconds;
        }
    }
}
