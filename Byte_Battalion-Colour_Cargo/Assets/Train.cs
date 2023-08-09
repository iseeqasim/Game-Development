using UnityEngine;

public class Train : MonoBehaviour
{
    public CargoContainer.CargoColor trainColor;
    public GameObject[] cargoContainers; // Array to hold references to the cargo containers

    private int nextAvailableCargoIndex = 0;

    private void Start()
    {
        // Deactivate all cargo containers initially
        foreach (var container in cargoContainers)
        {
            container.SetActive(false);
        }
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
            colliderSize.z += 0.14f; // Add 9 units to the X size of the box collider
            boxCollider.size = colliderSize;
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
            colliderSize.z -= 0.14f; // Subtract 9 units from the X size of the box collider
            boxCollider.size = colliderSize;
        }
    }
}
