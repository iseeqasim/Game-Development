using UnityEngine;

public class GM : MonoBehaviour
{
    private static GM instance;
    private int killScore;

    public static GM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GM>();
            }
            return instance;
        }
    }

    public void IncrementKillScore()
    {
        killScore++;
    }

    public int GetKillScore()
    {
        return killScore;
    }
}
