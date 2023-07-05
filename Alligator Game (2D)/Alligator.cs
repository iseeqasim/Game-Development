using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Alligator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 5f;
    public AudioSource shootingsound;

    public Text timerText;
    public float gameTime = 60f;
    public string gameOverScene = "GameOver";
    private float currentTime;


    private Animator anim;
    private SpriteRenderer spriteRenderer;


    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = gameTime;
        StartCoroutine(CountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.01f, 0, 0);
            anim.SetTrigger("Walk");
            spriteRenderer.flipX = false;
            isFacingRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.01f, 0, 0);
            anim.SetTrigger("Walk");
            spriteRenderer.flipX = true;
            isFacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isShoot", true);
            Shoot();
        }
        else
        {
            anim.SetBool("isShoot", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("End"))
        {
            transform.position = new Vector3(-7.3f, -1.77f, 0f);
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        if (!isFacingRight)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 180f); // Rotate the bullet when firing to the left
        }

        bulletRigidbody.velocity = new Vector2(isFacingRight ? bulletSpeed : -bulletSpeed, 0f);
        shootingsound.Play();
    }


    IEnumerator CountdownTimer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime -= 1f;
            UpdateTimerText();
        }

        // Time is up, load game over scene
        SceneManager.LoadScene(gameOverScene);
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Round(currentTime).ToString();
    }

}

