using UnityEngine;

public class DisableObjectsOnCollision : MonoBehaviour
{
    public GameObject objectToDisable1; // Assign in the Unity Inspector
    public GameObject objectToDisable2; // Assign in the Unity Inspector

    // Method to disable objects when called
    public void DisableObjects()
    {
        if (objectToDisable1 != null)
        {
            objectToDisable1.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object to disable 1 is not assigned in the inspector!");
        }

        if (objectToDisable2 != null)
        {
            objectToDisable2.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object to disable 2 is not assigned in the inspector!");
        }
    }
}
