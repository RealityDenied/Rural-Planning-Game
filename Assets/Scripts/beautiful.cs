using UnityEngine;

public class beautiful : MonoBehaviour
{
    public GameObject parentObject; // Assign the parent GameObject in the inspector
    private readonly Color[] villageColors = {
         new Color(0.93f * 0.7f, 0.87f * 0.7f, 0.74f * 0.7f), // Darker Beige
    new Color(0.76f * 0.7f, 0.69f * 0.7f, 0.57f * 0.7f), // Darker Light Brown
    new Color(0.87f * 0.7f, 0.94f * 0.7f, 0.98f * 0.7f), // Darker Light Blue
    new Color(0.71f * 0.7f, 0.82f * 0.7f, 0.65f * 0.7f), // Darker Soft Green
    new Color(0.96f * 0.7f, 0.91f * 0.7f, 0.60f * 0.7f), // Darker Muted Yellow
    new Color(0.88f * 0.7f, 0.85f * 0.7f, 0.88f * 0.7f), // Darker Soft Gray
    new Color(0.98f * 0.7f, 0.89f * 0.7f, 0.78f * 0.7f)  // Darker Light Peach
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
                // Assign a random color from the village palette
                Color houseColor = GetRandomVillageColor();
                renderer.material.color = houseColor;
            }
        }
    }

    // Get a random color from the village palette
    private Color GetRandomVillageColor()
    {
        int randomIndex = Random.Range(0, villageColors.Length);
        return villageColors[randomIndex];
    }
}
