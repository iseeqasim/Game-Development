using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float destroyDelay = 2f;

    private Animator anim;
    private KillsManager scoreManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scoreManager = FindObjectOfType<KillsManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            anim.SetTrigger("Dead");
            Destroy(gameObject, destroyDelay);
            Destroy(collision.gameObject);

            if (scoreManager != null)
            {
                scoreManager.IncreaseScore();
            }
        }
    }
}
