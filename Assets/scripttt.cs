using UnityEngine;
using UnityEngine.UI;

public class DropdownAnimator : MonoBehaviour
{
    public Button[] buttons; // Assign the dropdown buttons here
    public float tweenDuration = 0.5f; // Duration for the dropdown animation
    public float spacing = 5f; // Space between each button

    private bool isExpanded = false; // To track dropdown state
    private Vector3[] originalPositions; // Store original positions
    [SerializeField] GameObject ppanel;

    void Start()
    {
        // Store the original positions of the buttons
        originalPositions = new Vector3[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalPositions[i] = buttons[i].transform.localPosition;
        }
    }

    // Method to be called on the button click
    public void OnDropdownToggle()
    {
        Debug.Log(" workinggggj");
        if (isExpanded)
        {
            Collapse();
            Debug.Log("Now collapsing");
        }
        else
        {
            Expand();
            Debug.Log("Now expanding");
        }

        // Rotate the button (this GameObject) by 180 degrees around X-axis
        float targetRotation = isExpanded ? 0 : 180; // Rotate based on the new state
        LeanTween.rotateZ(gameObject, targetRotation, tweenDuration / 2).setEase(LeanTweenType.easeInOutCubic);

        // Toggle the state after animation triggers
        isExpanded = !isExpanded;
    }

    private void Expand()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
            // Tween each button downwards with spacing
            Vector3 targetPosition;
            
            targetPosition = originalPositions[i] + new Vector3(0, -spacing - (i+10), 0);
            LeanTween.moveLocal(buttons[i].gameObject, targetPosition, tweenDuration).setEase(LeanTweenType.easeOutCubic);
            
        }
    }

    private void Collapse()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);

            // Tween buttons back to their original positions
            LeanTween.moveLocal(buttons[i].gameObject, originalPositions[i], tweenDuration).setEase(LeanTweenType.easeInCubic);
        }
    }

    public void expandBar(){
        // ppanel.SetActive(false);
        if(ppanel.activeSelf){
            ppanel.SetActive(false);
        }
        else{
            ppanel.SetActive(true);
        }
    }
    
}
