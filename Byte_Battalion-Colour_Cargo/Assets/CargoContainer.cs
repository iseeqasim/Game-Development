using UnityEngine;

public class CargoContainer : MonoBehaviour
{
    public enum CargoColor { Red, Blue, Yellow }

    public bool enableRed = true;
    public bool enableBlue = true;
    public bool enableYellow = true;

    public string customHexRed = "#FF3217"; // Custom hex color for Red
    public string customHexBlue = "#0000FF"; // Custom hex color for Blue
    public string customHexYellow = "#FFFF00"; // Custom hex color for Yellow

    public Color customEmissionRed = new Color(135f, 0f, 0f); // Custom emission color for Red (R=1, G=0, B=0)
    public Color customEmissionBlue = new Color(0f, 0f, 1f); // Custom emission color for Blue (R=0, G=0, B=1)
    public Color customEmissionYellow = new Color(1f, 1f, 0f); // Custom emission color for Yellow (R=1, G=1, B=0)

    public float moveSpeed = 5f; // Adjust this to control the speed of the cargo containers

    private CargoColor color;

    public GameObject gameoverpanel;
    private void Start()
    {
        // Randomly assign a color to the cargo container based on enabled colors
        gameoverpanel.SetActive(false);
        SetRandomColorBasedOnEnabled();

        // Set the cube's color based on the cargo color
        SetColorBasedOnCargo();
    }

    private void SetRandomColorBasedOnEnabled()
    {
        bool[] enabledColors = { enableRed, enableBlue, enableYellow };
        int enabledCount = 0;
        foreach (bool enabled in enabledColors)
        {
            if (enabled)
            {
                enabledCount++;
            }
        }

        int randomIndex = Random.Range(0, enabledCount);

        int currentIndex = 0;
        for (int i = 0; i < enabledColors.Length; i++)
        {
            if (enabledColors[i])
            {
                if (currentIndex == randomIndex)
                {
                    color = (CargoColor)i;
                    break;
                }
                currentIndex++;
            }
        }
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
                    if (enableRed && trainName == "Red")
                    {
                        train.ActivateNextCargo();
                    }
                    break;
                case CargoColor.Blue:
                    if (enableBlue && trainName == "Blue")
                    {
                        train.ActivateNextCargo();
                    }
                    break;
                case CargoColor.Yellow:
                    if (enableYellow && trainName == "Yellow")
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
        Time.timeScale = 0;
        gameoverpanel.SetActive(true);
    }
}
