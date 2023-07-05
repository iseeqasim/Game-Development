using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gun : MonoBehaviour
{
    public GameObject fps;
    public int maxBullets = 20;
    private int bulletsLeft;
    public Text bulletsLeftText;
    float range = 500;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = maxBullets;
        UpdateBulletsLeftText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletsLeft > 0)
            {
                shoot();
                bulletsLeft--;
                UpdateBulletsLeftText();

                // Check if bullets are zero
                if (bulletsLeft == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range))
        {
            if (hit.transform.name.StartsWith("enemy"))
            {
                enemyScript enemy = hit.transform.GetComponent<enemyScript>();
                enemy.die();
            }
        }
    }

    private void UpdateBulletsLeftText()
    {
        bulletsLeftText.text = "Bullets Left: " + bulletsLeft.ToString();
    }
}
