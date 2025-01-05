using UnityEngine;

public class water : MonoBehaviour
{
    public GameObject parentObject; // Assign the parent GameObject in the inspector
    private readonly Color[] waterColors = {
        new Color(0.0f, 0.5f, 0.75f),  // Deep Blue
        new Color(0.0f, 0.6f, 0.8f),  // Ocean Blue
        new Color(0.0f, 0.75f, 0.75f), // Teal
        new Color(0.0f, 0.8f, 0.6f),  // Aqua Green
        new Color(0.3f, 0.75f, 0.9f), // Sky Blue
        new Color(0.2f, 0.6f, 0.8f),  // River Blue
        new Color(0.1f, 0.65f, 0.85f) // Lagoon Blue
    };

    void Start()
    {
        if (parentObject == null)
        {
            Debug.LogError("Parent Object is not assigned!");
            return;
        }

        // Iterate through all child objects
        foreach (Transform child in parentObject.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Assign a random water-like color
                Color waterColor = GetRandomWaterColor();
                renderer.material.color = waterColor;
            }
        }
    }

    // Get a random water-like color from the palette
    private Color GetRandomWaterColor()
    {
        int randomIndex = Random.Range(0, waterColors.Length);
        return waterColors[randomIndex];
    }
}
