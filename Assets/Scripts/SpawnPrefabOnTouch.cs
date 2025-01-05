using UnityEngine;

public class SpawnPrefabOnTouch : MonoBehaviour
{
    [Header("Prefab to Spawn")]
    public GameObject prefab; // The prefab to spawn

    [Header("Layer Mask for Terrain")]
    public LayerMask terrainLayer; // Assign the Terrain layer here

    [Header("Rotation of Spawned Prefab")]
    public Quaternion spawnRotation = Quaternion.identity; // Editable rotation in Inspector

    void Update()
    {
        // Check if there is any touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch is in the "Began" phase
            if (touch.phase == TouchPhase.Began)
            {
                // Convert touch position to a Ray
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Perform a raycast to detect the terrain
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
                {
                    // Spawn the prefab at the hit point with the specified rotation
                    if (prefab != null)
                    {
                        Instantiate(prefab, hit.point, spawnRotation);
                    }
                    else
                    {
                        Debug.LogError("Prefab is not assigned!");
                    }
                }
            }
        }
    }
}
