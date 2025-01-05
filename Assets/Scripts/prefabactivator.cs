using UnityEngine;

public class prefabactivator4 : MonoBehaviour
{
    public GameObject WindmillStateManager;
    public void WindmillState(){
        Debug.Log("hjfgh");
            if (gameObject.GetComponent<SpawnPrefabOnTouch>().enabled)
            {
                // Disable the component if it's enabled
                gameObject.GetComponent<SpawnPrefabOnTouch>().enabled = false;
            }
            else
            {
                // Enable the component if it's disabled
                gameObject.GetComponent<SpawnPrefabOnTouch>().enabled = true;
            }
        
    }

    
    
}
