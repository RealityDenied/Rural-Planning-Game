using UnityEngine;

public class FaceCameraNegativeX : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Cache the main camera reference
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // Calculate the direction from the plane to the camera
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            // Compute the target rotation to face the camera with a +90 degree rotation on the X-axis
            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);

            // Apply an additional 90-degree rotation on the X-axis
            targetRotation *= Quaternion.Euler(90f, 0f, 180f);

            // Set the plane's rotation to face the camera with the extra X-axis rotation
            transform.rotation = targetRotation;
        }
    }
}
