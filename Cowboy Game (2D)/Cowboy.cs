using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cowboy : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 6f;
    public AudioSource coinCollected;
    public Text scoreText;

    private GameManager gameManager;
    private float score = 0;

    private Rigidbody2D rb;
    private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    private bool isRunning = false;
    private bool isJumping = false;
    private bool isSliding = false;

    private bool isTouching = false;
    private float touchStartPosX;

    public Button jumpButton; // Reference to the jump button

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        gameManager = FindObjectOfType<GameManager>();

        // Register a callback for the jump button
        jumpButton.onClick.AddListener(Jump);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            touchStartPosX = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
        }

        if (isTouching)
        {
            float touchDeltaX = (Input.mousePosition.x - touchStartPosX) / Screen.width;

            if (Mathf.Abs(touchDeltaX) > 0.1f)
            {
                dirX = touchDeltaX * moveSpeed;
                isRunning = true;
            }
            else
            {
                dirX = 0f;
                isRunning = false;
            }
        }
        else
        {
            dirX = 0f;
            isRunning = false;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                touchStartPosX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                float touchDeltaX = (touch.position.x - touchStartPosX) / Screen.width;

                if (Mathf.Abs(touchDeltaX) > 0.1f)
                {
                    dirX = touchDeltaX * moveSpeed;
                    isRunning = true;
                }
                else
                {
                    dirX = 0f;
                    isRunning = false;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
                dirX = 0f;
                isRunning = false;
            }
        }

        if (Input.GetButtonDown("Jump") && !isJumping && !isRunning)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 10f;
        else
            moveSpeed = 5f;

        SetAnimationState();
        CheckWhereToFace();

        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void SetAnimationState()
    {
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isSliding", isSliding);
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Coin"))
        {
            gameManager.score += 5;
            scoreText.text = "Score: " + gameManager.score.ToString();
            coinCollected.Play();
            Destroy(collision.gameObject);

            gameManager.CheckScore();
        }

        if (collision.gameObject.name.StartsWith("End"))
        {
            transform.position = new Vector3(2.31f, 1.32f, 0f);
        }
    }

    IEnumerator PlaySlideAnimation()
    {
        anim.SetBool("isJumping", true);
        isJumping = true;

        // Wait for the next frame
        yield return null;

        // Get the current state of the animator
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // Wait until the jump animation reaches a specific frame
        while (stateInfo.IsName("Jump") && stateInfo.normalizedTime < 0.5f)
        {
            yield return null;
            stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        }

        // Apply the jump force
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        yield return new WaitForSeconds(1.5f); // Adjust the duration of the sliding animation here if needed

        anim.SetBool("isJumping", false);
        isJumping = false;
        anim.SetBool("isSliding", true);
        isSliding = true;

        yield return new WaitForSeconds(1f); // Adjust the duration of the sliding animation here if needed

        anim.SetBool("isSliding", false);
        isSliding = false;
    }

    void Jump()
    {
        if (!isJumping && !isRunning)
        {
            anim.SetBool("isJumping", true);
            isJumping = true;
            StartCoroutine(PlaySlideAnimation());
        }
    }
}
