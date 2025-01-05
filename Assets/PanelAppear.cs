using UnityEngine;
using UnityEngine.UI;

public class PanelAppear : MonoBehaviour
{
    public GameObject[] btnArray;  // Array of Buttons
    public GameObject[] panelArray;  // Array of Panels

    void Start()
    {
        // Ensure both arrays are of the same length
        if (btnArray.Length != panelArray.Length)
        {
            Debug.LogError("Button array and panel array must have the same length.");
            return;
        }

        // Add click listeners to each button
        for (int i = 0; i < btnArray.Length; i++)
        {
            int index = i; // Capture the current index for the closure
            Button button = btnArray[index].GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnButtonClicked(index));
            }
            else
            {
                Debug.LogError($"GameObject at index {index} in btnArray is not a Button.");
            }
        }

        // Hide all panels initially
        foreach (var panel in panelArray)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }

    private void OnButtonClicked(int index)
    {
        // Ensure index is valid
        if (index < 0 || index >= panelArray.Length)
        {
            Debug.LogError("Invalid panel index.");
            return;
        }

        // Hide all panels
        foreach (var panel in panelArray)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }

        // Show the corresponding panel
        if (panelArray[index] != null)
        {
            panelArray[index].SetActive(true);
        }
    }
}