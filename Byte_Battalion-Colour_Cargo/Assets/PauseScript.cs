using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused=false;
    public GameObject pausecanvas;
    public GameObject leveluipanel;
    public string currentScene;

    void Start()
    {
        pausecanvas.SetActive(false);
        currentScene= SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Pause()
    {
        
        if (!isPaused)
        {
            leveluipanel.SetActive(false);
            Time.timeScale = 0.0f;
            isPaused = true;
            pausecanvas.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pausecanvas.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale=1.0f;
        SceneManager.LoadScene(currentScene);
    }
}
