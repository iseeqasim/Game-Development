using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIPanel;
    public GameObject UIPanel2;
    public bool EndlessStarted;
    public NextLevelLoader nll;
    void Start()
    {
        nll = GameObject.FindObjectOfType<NextLevelLoader>();
        //NextLevelLoader endlessbool=GetComponent<NextLevelLoader>();
        //EndlessStarted=nll.GetisEndless();
        EndlessStarted = nll.isEndless;
        Debug.Log(EndlessStarted+" is the value of EndlessStarted in leveluihandlerscript");
        if (nll.GetisEndless()) 
            {
            UIPanel.SetActive(false);
            UIPanel2.SetActive(true);
            }
        else
        {
            UIPanel2.SetActive(false);
            UIPanel.SetActive(true);
        }
        StartCoroutine(PanelHide());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator PanelHide()
    {
        yield return new WaitForSeconds(2);
        if (nll.isEndless)
        {
            UIPanel2.SetActive(false);
        }
        else
        {
            UIPanel.SetActive(false);
        }
    }
}
