using UnityEngine;

public class CargoContainer : MonoBehaviour
{
    public enum CargoColor { Red, Blue, Yellow }

    public CargoColor color;
    public string customHexRed = "#FF3217"; // Custom hex color for Red
    public string customHexBlue = "#0000FF"; // Custom hex color for Blue
    public string customHexYellow = "#FFFF00"; // Custom hex color for Yellow

    public Color customEmissionRed = new Color(135f, 0f, 0f); // Custom emission color for Red (R=1, G=0, B=0)
    public Color customEmissionBlue = new Color(0f, 0f, 1f); // Custom emission color for Blue (R=0, G=0, B=1)
    public Color customEmissionYellow = new Color(1f, 1f, 0f); // Custom emission color for Yellow (R=1, G=1, B=0)

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
        Material[] materials = cubeRenderer.materials; // Get all materials

        foreach (Material material in materials)
        {
            switch (color)
            {
                case CargoColor.Red:
                    ColorUtility.TryParseHtmlString(customHexRed, out Color redColor);
                    material.color = redColor;
                    material.SetColor("_EmissionColor", customEmissionRed);
                    break;
                case CargoColor.Blue:
                    ColorUtility.TryParseHtmlString(customHexBlue, out Color blueColor);
                    material.color = blueColor;
                    material.SetColor("_EmissionColor", customEmissionBlue);
                    break;
                case CargoColor.Yellow:
                    ColorUtility.TryParseHtmlString(customHexYellow, out Color yellowColor);
                    material.color = yellowColor;
                    material.SetColor("_EmissionColor", customEmissionYellow);
                    break;
                    // Add more cases for other colors if needed
            }
        }

        cubeRenderer.materials = materials; // Update the materials array
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
                case CargoColor.Yellow:
                    if (trainName == "Yellow")
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