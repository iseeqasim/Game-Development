using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        // Get the GameManager instance
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // Get the score value from GameManager
            float score = gameManager.score;

            // Display the score value
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
