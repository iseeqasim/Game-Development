using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficHit : MonoBehaviour
{
    // Start is called before the first frame update

void OnCollisionEnter(Collision other)
{
    if(other.gameObject.GetComponent<TrafficCar>())
    other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, 2)*5*Time.deltaTime,ForceMode.Impulse);
}
}
