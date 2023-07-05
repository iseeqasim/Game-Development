using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillsManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();

        if (score >= 5)
        {
            LoadYouWinScene();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Kills: " + score.ToString();
        }
    }

    private void LoadYouWinScene()
    {
        SceneManager.LoadScene("YouWin");
    }
}
