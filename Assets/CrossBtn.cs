using UnityEngine;
using UnityEngine.UI;

public class CrossBtn : MonoBehaviour
{
    void Start()
    {
        GameObject panelll = transform.parent.gameObject;

        // Use a lambda to pass the panel as an argument to the method
        gameObject.GetComponent<Button>().onClick.AddListener(() => CrossBtnClickk(panelll));
    }

    public void CrossBtnClickk(GameObject panelll)
    {
        panelll.SetActive(false);
    }
}
