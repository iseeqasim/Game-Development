using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countup : MonoBehaviour
{
    double Timer = 0.0;
    public Text guiText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        int seconds = ((int)Timer % 60);
        guiText.text = "" + seconds;
    }
}
