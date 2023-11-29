using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberLoader : MonoBehaviour
{
    public Text LevelIntroPanel;
    public int LevelNumber;
    public NextLevelLoader nll;
    // Start is called before the first frame update
    void Start()
    {
        nll = GameObject.FindObjectOfType<NextLevelLoader>();
        //NextLevelLoader IntroPanelNumber=GetComponent<NextLevelLoader>();
        LevelNumber =nll.GetEndlesslevelnumber();
        
        //LevelNumber = nll.Endlesslevelnumber;
        LevelIntroPanel.text=LevelIntroPanel.text+LevelNumber.ToString();
        Debug.Log(LevelNumber + "is the level number in Levelnumber loader script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
