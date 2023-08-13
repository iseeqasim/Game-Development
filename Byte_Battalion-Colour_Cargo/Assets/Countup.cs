using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countup : MonoBehaviour
{
    double Timer = 0.0;
    public Text guiText;
    public Text guiText2;
    
    // Start is called before the first frame update
    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
        if (bestTime == Mathf.Infinity)
        {
            guiText2.text = "NA";
        }
        else{
            guiText2.text = bestTime.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        int seconds = ((int)Timer);
        guiText.text = "" + seconds;
    }
}
