using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornScript : MonoBehaviour
{
 [SerializeField] private AudioSource HornSource;
 [SerializeField] private AudioClip Horn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

if(Input.GetKey(KeyCode.H))
{
    HornSource.PlayOneShot(Horn);

    }
}

}