using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dino : MonoBehaviour
{
    Animator anim;
    public CharacterController2D controller;
    float righthorizontalMove = 40f;
    float lefthorizontalMove = -40f;
    bool jump = false;
    bool crouch = false;
    public Text ScoreText;
    public Text HealthText;

    private float score = 0;
    private float health = 50;

    public AudioSource applecollected;
    private float startTouchPosition, endTouchPosition;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        HealthText.text = "Health: " + health.ToString();
        ScoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //  transform.Translate(Vector2.up * 250 * Time.fixedDeltaTime);
        //}


        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position.y;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position.y;
                if (endTouchPosition > startTouchPosition)
                {
                    transform.Translate(Vector2.up * 250 * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //   controller.Move(righthorizontalMove * Time.fixedDeltaTime, crouch, jump);
        //    anim.SetTrigger("Walk");
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    controller.Move(lefthorizontalMove * Time.fixedDeltaTime, crouch, jump);
        //    anim.SetTrigger("Walk");
        //}

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2 && touch.position.y > Screen.height / 8)
            {
                controller.Move(lefthorizontalMove * Time.fixedDeltaTime, crouch, jump);
                anim.SetTrigger("Walk");
            }

            if (touch.position.x > Screen.width / 2 && touch.position.y > Screen.height / 8)
            {

                controller.Move(righthorizontalMove * Time.fixedDeltaTime, crouch, jump);
                anim.SetTrigger("Walk");
            }
        }
        else
        {
            anim.SetTrigger("Walk");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Apple"))
        {
            score = score + 5;
            ScoreText.text = "Score: " + score.ToString();
            applecollected.Play();
            Destroy(collision.gameObject);
            

        }
        if (collision.gameObject.name.StartsWith("Saw"))
        {
            health = health -5;
            HealthText.text = "Health: " + health.ToString();
            if (health == 0)
            {
                HealthText.gameObject.SetActive(false);
                StartCoroutine(DelayedDestruction());
                anim.SetTrigger("Triggerdead");
                SceneManager.LoadScene("GameOver2");
     
            }

        }

        if (collision.gameObject.name.StartsWith("End"))
        {
            transform.position = new Vector3(-9.66f, -0.14f, 0f);
        }


    }

    IEnumerator DelayedDestruction()
    {
        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.6f);

        // Destroy the current game object
        Destroy(transform.gameObject);
    }
}
