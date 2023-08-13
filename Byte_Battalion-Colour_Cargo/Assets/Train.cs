using UnityEngine;

public class Train : MonoBehaviour
{
    public CargoContainer.CargoColor trainColor;
    public GameObject[] cargoContainers; // Array to hold references to the cargo containers

    public int activateThreshold = 5;
    public GameObject spawnerB;
    public GameObject additionalObject1; // Reference to the first additional GameObject to activate
    public GameObject additionalObject2;
    public GameObject additionalObject3;
    public GameObject objectToDeactivate;
    private bool movementStarted = false;
    private bool additionalObjectsActivated = false; // Flag to track if additional objects are activated
    private float timer = 0f;
    public float delayTime = 5f;
    public float movementSpeed = 0.3f;


    public AudioSource cargoActivationSound;
    public AudioSource cargoDeactivationSound;
    public AudioSource TrainSound;
    public AudioSource HornSound;

    private int nextAvailableCargoIndex = 0;

    private void Start()
    {
        // Deactivate all cargo containers initially
        foreach (var container in cargoContainers)
        {
            container.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the activation threshold is reached
        if (nextAvailableCargoIndex >= activateThreshold)
        {

            if (!movementStarted)
            {
                // Disable collision detection if movement starts
                GetComponent<BoxCollider>().enabled = false;
                movementStarted = true;
                if (HornSound != null)
                {
                    HornSound.Play();
                }
                if (TrainSound != null)
                {
                    TrainSound.Play();
                }
            }
            // Move the train forward
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);




            // Activate the "Spawner B" GameObject if it's set
            if (spawnerB != null)
            {
                spawnerB.SetActive(true);
            }

            // Deactivate the specified GameObject if it's set
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            // Activate additional objects after the delay time
            if (!additionalObjectsActivated)
            {
                timer += Time.deltaTime;
                if (timer >= delayTime)
                {
                    if (additionalObject1 != null)
                    {
                        additionalObject1.SetActive(true);
                    }
                    if (additionalObject2 != null)
                    {
                        additionalObject2.SetActive(true);
                    }
                    if (additionalObject3 != null)
                    {
                        additionalObject3.SetActive(true);
                    }
                    additionalObjectsActivated = true; // Set the flag to prevent repeated activation
                }
            }
        }
    }

    public int GetNextAvailableCargoIndex()
    {
        return nextAvailableCargoIndex;
    }

    public bool IsMovementStarted()
    {
        return movementStarted;
    }


    public void ActivateNextCargo()
    {
        // Check if there are available cargo containers
        if (nextAvailableCargoIndex < cargoContainers.Length)
        {
            // Activate the next available cargo container
            cargoContainers[nextAvailableCargoIndex].SetActive(true);
            nextAvailableCargoIndex++;

            // Adjust the size of the box collider when a new container is added
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Vector3 colliderSize = boxCollider.size;
            colliderSize.z += 0.07f;
            boxCollider.size = colliderSize;

            Vector3 colliderCenter = boxCollider.center;
            colliderCenter.z -= 0.035f;
            boxCollider.center = colliderCenter;

            if (cargoActivationSound != null)
            {
                cargoActivationSound.Play();
            }
        }
    }


    public void DeactivateOneCargo()
    {
        // Check if there are available cargo containers to deactivate
        if (nextAvailableCargoIndex > 0)
        {
            // Deactivate the last activated cargo container
            nextAvailableCargoIndex--;
            cargoContainers[nextAvailableCargoIndex].SetActive(false);

            // Adjust the size of the box collider when a container is deactivated
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Vector3 colliderSize = boxCollider.size;
            colliderSize.z -= 0.07f;
            boxCollider.size = colliderSize;

            Vector3 colliderCenter = boxCollider.center;
            colliderCenter.z += 0.035f;
            boxCollider.center = colliderCenter;

            if (cargoDeactivationSound != null)
            {
                cargoDeactivationSound.Play();
            }
        }
    }


    public void Deactivatetwocargos()
    {
        // Check if there are any available cargo containers to deactivate
        if (nextAvailableCargoIndex > 0)
        {
            int containersToDeactivate = Mathf.Min(2, nextAvailableCargoIndex); // Calculate how many containers to deactivate

            // Deactivate the specified number of cargo containers
            for (int i = 0; i < containersToDeactivate; i++)
            {
                nextAvailableCargoIndex--;
                cargoContainers[nextAvailableCargoIndex].SetActive(false);
            }

            // Adjust the size of the box collider when containers are deactivated
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Vector3 colliderSize = boxCollider.size;
            colliderSize.z -= 0.07f * containersToDeactivate;
            boxCollider.size = colliderSize;

            Vector3 colliderCenter = boxCollider.center;
            colliderCenter.z += 0.035f * containersToDeactivate;
            boxCollider.center = colliderCenter;

            if (cargoDeactivationSound != null)
            {
                cargoDeactivationSound.Play();
            }
        }
    }


}