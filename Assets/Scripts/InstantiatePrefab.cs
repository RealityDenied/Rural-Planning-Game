using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [Header("Prefab to Instantiate")]
    public GameObject prefabC; // The prefab to instantiate

    void Start()
    {
        if (prefabC == null)
        {
            Debug.LogError("Prefab C is not assigned!");
            return;
        }

        // Iterate through all child GameObjects of the parent
        foreach (Transform child in transform)
        {
            // Check if the child has a Renderer component (to get the center of the child)
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                // Get the center of the child's bounds (center of its collider or mesh)
                Vector3 childCenter = childRenderer.bounds.center;

                // Calculate the new position for prefab C based on the child's center
                Vector3 newPosition = childCenter + new Vector3(0, +4.9f, 0);
                Debug.Log("Child Center Position: " + childCenter);

                // Instantiate prefab C at the new position
                GameObject instance = Instantiate(prefabC, newPosition, Quaternion.identity);

                // Parent the instantiated object to the current child
                instance.transform.SetParent(child);

                // Optionally adjust local position if needed (but the world position is set correctly)
                // instance.transform.localPosition = child.InverseTransformPoint(newPosition);
            }
            else
            {
                Debug.LogWarning("Child does not have a Renderer component, skipping...");
            }
        }
    }
}
