using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCoin : MonoBehaviour
{
    public GameObject Coin;
    private Vector2 coinpos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            coinpos = new Vector2(Random.Range(0, 56), Random.Range(0.5f, 2));
            Instantiate(Coin, coinpos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
