using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject alligator;
    private Vector3 offset;
    private int stepsToMoveCamera = 3; // Number of steps the alligator takes before the camera starts moving
    private int currentStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - alligator.transform.position;
    }

    // LateUpdate is called once per frame after other Update calls
    void LateUpdate()
    {
        if (currentStep <= stepsToMoveCamera)
        {
            if (alligator.transform.position.x > transform.position.x)
            {
                currentStep++;
            }
        }

        if (currentStep > stepsToMoveCamera)
        {
            Vector3 targetPosition = new Vector3(alligator.transform.position.x, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }
}
