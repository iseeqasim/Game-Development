using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    public Vector2 pos3;
    public Vector2 pos4;
    public Vector2 posdifff = new Vector2(5f, 0f);
    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        pos3 = transform.position;
        pos4 = pos3 + posdifff;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(pos3, pos4, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
