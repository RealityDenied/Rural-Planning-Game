using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [Header("Prefab to Instantiate")]
    public GameObject prefabC;

    void Start()
    {
        if (prefabC == null)
        {
            Debug.LogError("Prefab C is not assigned!");
            return;
        }

        foreach (Transform child in transform)
        {

            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
           
                Vector3 childCenter = childRenderer.bounds.center;

                Vector3 newPosition = childCenter + new Vector3(0, +4.9f, 0);
                Debug.Log("Child Center Position: " + childCenter);

                GameObject instance = Instantiate(prefabC, newPosition, Quaternion.identity);

                instance.transform.SetParent(child);

            }
            else
            {
                Debug.LogWarning("Child does not have a Renderer component, skipping...");
            }
        }
    }
}
