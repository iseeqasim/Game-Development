using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardScript : MonoBehaviour
{
    public GameObject selectlevelpanel;
    public GameObject howtoplaypanel;
    // Start is called before the first frame update
    void Start()
    {
        selectlevelpanel.SetActive(false);
        howtoplaypanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Leaderboard()
    {
        Debug.Log("Leaderboard button pressed");
        selectlevelpanel.SetActive(true);
    }
    public void back()
    {
        selectlevelpanel.SetActive(false);
    }
    public void howtoplay()
    {
        howtoplaypanel.SetActive(true);
    }
    public void back2()
    {
        howtoplaypanel.SetActive(false);
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }

}
