using UnityEngine;

public class Cube : MonoBehaviour
{
    public enum CargoColor { Red, Blue, Green }

    public CargoColor color;
    public float moveSpeed = 5f; // Adjust this to control the speed of the cargo containers

    private void Start()
    {
        // Randomly assign a color to the cargo container
        color = (CargoColor)Random.Range(0, 3);

        // Set the cube's color based on the cargo color
        SetColorBasedOnCargo();
    }

    private void SetColorBasedOnCargo()
    {
        Renderer cubeRenderer = GetComponent<Renderer>();
        switch (color)
        {
            case CargoColor.Red:
                cubeRenderer.material.color = Color.red;
                break;
            case CargoColor.Blue:
                cubeRenderer.material.color = Color.blue;
                break;
            case CargoColor.Green:
                cubeRenderer.material.color = Color.green;
                break;
        }
    }

    private void Update()
    {
        // Move the cargo container vertically along the tracks
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the cube collides with a train
        if (collision.gameObject.CompareTag("Train"))
        {
            // Get the name of the collided train
            string trainName = collision.gameObject.name;

            // Check the color of the cube and call ActivateNextCargo on the corresponding train
            Train train = collision.gameObject.GetComponent<Train>();
            switch (color)
            {
                case CargoColor.Red:
                    if (trainName == "Red")
                    {
                        train.ActivateNextCargo();
                    }
                    break;
                case CargoColor.Blue:
                    if (trainName == "Blue")
                    {
                        train.ActivateNextCargo();
                    }
                    break;
                case CargoColor.Green:
                    if (trainName == "Green")
                    {
                        train.ActivateNextCargo();
                    }
                    break;
            }

            // If the color of the cube does not match the color of the train,
            // call the method in the train to deactivate one cargo container
            if (train.trainColor != color)
            {
                train.DeactivateOneCargo();
            }
        }

        // Destroy the cube after the collision
        Destroy(gameObject);
    }
}
