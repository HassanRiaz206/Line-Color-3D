using UnityEngine;

public class ChildObjectManager : MonoBehaviour
{
    public GameObject mainPlayer; // Assign the main player GameObject in the inspector
    public GameObject child1; // Assign the first child GameObject in the inspector
    public GameObject child2; // Assign the second child GameObject in the inspector

    private static readonly string SelectedChildKey = "SelectedChild"; // Key for saving/loading the selected child
    private static readonly string MainPlayerRendererStateKey = "MainPlayerRendererEnabled"; // Key for saving the main player's MeshRenderer state

    void Start()
    {
        LoadState();
    }

    private void LoadState()
    {
        // Load and apply the main player's MeshRenderer state
        bool isRendererEnabled = PlayerPrefs.GetInt(MainPlayerRendererStateKey, 1) == 1; // Default to enabled
        SetMainPlayerRendererState(isRendererEnabled);

        // Load and activate only the previously active child GameObject, if any
        string selectedChildName = PlayerPrefs.GetString(SelectedChildKey, string.Empty);
        if (!string.IsNullOrEmpty(selectedChildName) && mainPlayer != null)
        {
            GameObject selectedChild = null;
            foreach (Transform child in mainPlayer.transform)
            {
                if (child.name == selectedChildName)
                {
                    selectedChild = child.gameObject;
                    break; // Found the previously active child, no need to continue
                }
            }

            // If a previously active child is found, activate it
            if (selectedChild != null)
            {
                selectedChild.SetActive(true);
                // If a child is set to active, ensure the main player's MeshRenderer is disabled
                SetMainPlayerRendererState(false);
            }
        }
    }

    private void SetMainPlayerRendererState(bool isEnabled)
    {
        MeshRenderer meshRenderer = mainPlayer.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = isEnabled;

            // If the MeshRenderer is disabled, also disable the specified children
            if (!isEnabled)
            {
                if (child1 != null) child1.SetActive(false);
                if (child2 != null) child2.SetActive(false);
            }

            PlayerPrefs.SetInt(MainPlayerRendererStateKey, isEnabled ? 1 : 0); // Save the state
        }
    }
}
