using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float rotationSpeed = 0.1f; // Speed of rotation
    public float panSpeed = 0.05f; // Speed of panning
    public float minZoom = 10f; // Minimum zoom distance (currently not in use)
    public float maxZoom = 100f; // Maximum zoom distance (currently not in use)

    private Camera cameraComponent;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        if (cameraComponent == null)
        {
            Debug.LogError("This script must be attached to a GameObject with a Camera component.");
        }
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 1) // One finger for horizontal rotation
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;

                // Only allow horizontal rotation
                transform.Rotate(Vector3.up, -delta.x * rotationSpeed, Space.World);
            }
        }
        else if (Input.touchCount == 2) // Two fingers for panning
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
            {
                // Calculate average movement of the two fingers
                Vector2 panDelta = (touch0.deltaPosition + touch1.deltaPosition) / 2f;

                // Invert movement directions for panning
                Vector3 forwardMovement = -transform.forward * panDelta.y * panSpeed;  // Reverse forward/backward
                Vector3 rightMovement = -transform.right * panDelta.x * panSpeed;      // Reverse left/right

                // Update camera position in the XZ plane, keeping Y fixed
                Vector3 newPosition = transform.position + forwardMovement + rightMovement;
                newPosition.y = transform.position.y; // Keep the same Y position

                // Apply the new position
                transform.position = newPosition;
            }
        }
    }
}
