using UnityEngine;

public class TrainDragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;
    private TrainDragDrop lastDroppedOnTrain; // Keep track of the last train this one was dropped on

    // Smoothing parameters
    public float dragSmoothness = 10f;
    public float snapTolerance = 0.1f;

    // Track positions
    public float redTrackX = -19f;
    public float blueTrackX = 4.78f;
    public float greenTrackX = -7.5f;

    private void OnMouseDown()
    {
        // When the mouse button is pressed down on the train, enable dragging.
        isDragging = true;
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Disable the collider during the drag
            GetComponent<Collider>().enabled = false;

            // Get the mouse position in world coordinates.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            // Find the nearest track position and smooth the train movement to the new position.
            Vector3 targetPosition = FindNearestTrackPosition(mousePosition.x);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * dragSmoothness);

        }
    }


    private void OnMouseUp()
    {
        GetComponent<Collider>().enabled = true;
        // When the mouse button is released, disable dragging.
        isDragging = false;

        // Check if this train is overlapping with another train.
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        bool isDroppedOnTrain = false;
        foreach (Collider collider in colliders)
        {
            TrainDragDrop otherTrain = collider.GetComponent<TrainDragDrop>();
            if (otherTrain != null && otherTrain != this)
            {
                // Swap positions with the other train.
                SwapTrainsPosition(otherTrain);
                isDroppedOnTrain = true;
                break;
            }
        }

        // If not dropped on another train, snap back to the original track position.
        if (!isDroppedOnTrain)
        {
            SnapToOriginalTrack();
        }
    }

    private void SwapTrainsPosition(TrainDragDrop otherTrain)
    {
        // Swap the positions of this train and the other train.
        Vector3 tempPosition = otherTrain.transform.position;
        otherTrain.transform.position = initialPosition;
        transform.position = tempPosition;

        // Update the initial position to the new position after the swap.
        initialPosition = transform.position;

        // Keep track of the last train this one was dropped on.
        lastDroppedOnTrain = otherTrain;
    }

    private Vector3 FindNearestTrackPosition(float currentXPosition)
    {
        // Calculate the distances from the current X position to each track.
        float distanceToRed = Mathf.Abs(currentXPosition - redTrackX);
        float distanceToBlue = Mathf.Abs(currentXPosition - blueTrackX);
        float distanceToGreen = Mathf.Abs(currentXPosition - greenTrackX);

        // Find the minimum distance among the tracks.
        float minDistance = Mathf.Min(distanceToRed, distanceToBlue, distanceToGreen);

        // If the minimum distance is within the snap tolerance, snap to the nearest track.
        if (minDistance <= snapTolerance)
        {
            if (minDistance == distanceToRed)
            {
                return new Vector3(redTrackX, initialPosition.y, initialPosition.z);
            }
            else if (minDistance == distanceToBlue)
            {
                return new Vector3(blueTrackX, initialPosition.y, initialPosition.z);
            }
            else
            {
                return new Vector3(greenTrackX, initialPosition.y, initialPosition.z);
            }
        }

        // If not within the snap tolerance, return the current position to continue dragging smoothly.
        return new Vector3(currentXPosition, initialPosition.y, initialPosition.z);
    }

    private void SnapToOriginalTrack()
    {
        // Snap back to the initial position.
        transform.position = initialPosition;
    }
}
