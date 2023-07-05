using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float destroyDelay = 2f;

    private Vector3 direction;
    private bool isMovingUp = true;
  
    private void Start()
    {
        direction = Vector3.up;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (isMovingUp && transform.position.y >= 0.3f)
        {
            direction = Vector3.down;
            isMovingUp = false;
        }
        else if (!isMovingUp && transform.position.y <= -4f)
        {
            direction = Vector3.up;
            isMovingUp = true;
        }
    }


   


    private void OnDestroy()
    {
        Destroy(gameObject, destroyDelay);
    }
}
