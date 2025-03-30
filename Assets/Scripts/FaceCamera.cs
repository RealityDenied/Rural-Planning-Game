using UnityEngine;

public class FaceCameraNegativeX : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
           
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);

            targetRotation *= Quaternion.Euler(90f, 0f, 180f);

            transform.rotation = targetRotation;
        }
    }
}
