using UnityEngine;

public class ToggleChildButtons : MonoBehaviour
{
    public void SwitcherMethod()
    {
        Debug.Log("hello");
        // Ensure there are exactly two child buttons
        if (transform.childCount != 2)
        {
            Debug.LogError("The GameObject must have exactly 2 child buttons.");
            return;
        }

        // Get the first and second child buttons
        GameObject button1 = transform.GetChild(0).gameObject;
        GameObject button2 = transform.GetChild(1).gameObject;

        if(button1.activeSelf){
            button2.SetActive(true);
            button1.SetActive(false);

        }
        else if(button2.activeSelf){
            button1.SetActive(true);
            button2.SetActive(false);
        }
    }
}
