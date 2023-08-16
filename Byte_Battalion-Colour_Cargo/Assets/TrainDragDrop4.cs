using UnityEngine;

public class TrainDragDrop4 : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;
    private TrainDragDrop4 lastDroppedOnTrain; // Keep track of the last train this one was dropped on

    public bool enableMouseDown = true; // Enable or disable OnMouseDown behavior
    public bool enableMouseDrag = true; // Enable or disable OnMouseDrag behavior
    public bool enableMouseUp = true;


    // Smoothing parameters
    public float dragSmoothness = 1f;
    public float snapTolerance = 0f;

    // Track positions
    public float redTrackX = 168.852f;
    public float blueTrackX = 169.692f;
    public float greenTrackX = 169.274f;
    public float yellowTrackX = 170.1f;

    public float yIncreaseDuringDrag = 0.1737f; // Y position increase during drag
    public float zDecreaseDuringDrag = 0.297f;


    private void OnMouseDown()
    {
        if (!enableMouseDown)
            return;

        // When the mouse button is pressed down on the train, enable dragging.
        isDragging = true;
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (!enableMouseDrag)
            return;

        if (isDragging)
        {
            // Disable the collider during the drag
            GetComponent<Collider>().enabled = false;


            // Get the mouse position in world coordinates.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            // Find the nearest track position and smooth the train movement to the new position.
            Vector3 targetPosition = FindNearestTrackPosition(mousePosition.x);

            targetPosition.y += yIncreaseDuringDrag;
            targetPosition.z += zDecreaseDuringDrag;

            // Clamp the target position within the specified x-axis range
            targetPosition.x = Mathf.Clamp(targetPosition.x, 168.85f, 170.11f);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * dragSmoothness * 42f);

        }
    }


    private void OnMouseUp()
    {
        if (!enableMouseUp)
            return;

        GetComponent<Collider>().enabled = true;
        // When the mouse button is released, disable dragging.
        isDragging = false;

        // Check if this train is overlapping with another train.
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        bool isDroppedOnTrain = false;
        foreach (Collider collider in colliders)
        {
            TrainDragDrop4 otherTrain = collider.GetComponent<TrainDragDrop4>();
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

    private void SwapTrainsPosition(TrainDragDrop4 otherTrain)
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
        float distanceToYellow = Mathf.Abs(currentXPosition - yellowTrackX);

        // Find the minimum distance among the tracks.
        float minDistance = Mathf.Min(distanceToRed, distanceToBlue, distanceToGreen, distanceToYellow);

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
            else if (minDistance == distanceToGreen)
            {
                return new Vector3(greenTrackX, initialPosition.y, initialPosition.z);
            }
            else
            {
                return new Vector3(yellowTrackX, initialPosition.y, initialPosition.z);
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