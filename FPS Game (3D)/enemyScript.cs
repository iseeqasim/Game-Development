using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    public GameObject fps;
    public GameObject enemy;
    public Text killsText;
    Animator anim;

    private int kills;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isdead", false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(fps.transform);
    }

    public void die()
    {
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        enemyAnimator.SetBool("isdead", true);
        IncrementKills();
    }

    private void IncrementKills()
    {
        kills++;
        killsText.text = "Kills: " + kills.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == fps)
        {
            SceneManager.LoadScene("GameOver2");
        }
    }

    // Add this method to prevent the kills variable from being decremented
    public void ResetKills()
    {
        kills = 0;
    }
}
