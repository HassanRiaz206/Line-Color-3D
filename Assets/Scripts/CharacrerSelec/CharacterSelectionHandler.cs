using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionHandler : MonoBehaviour
{
    public GameObject mainPlayer; // Assign the main player GameObject in the inspector
    public GameObject childToShow; // Assign the child GameObject of the main player that should be enabled when this button is clicked
    public Image lockedImage; // Assign the UI Image that indicates if the character is locked

    private static GameObject currentlyActiveChild; // Keep track of the currently active child GameObject
    private static readonly string SelectedChildKey = "SelectedChild"; // Key for saving/loading the selected child
    private static readonly string MainPlayerRendererStateKey = "MainPlayerRendererEnabled"; // Key for saving the main player's MeshRenderer state
     
    void Start()
    {
        // Ensure the button has a listener for the click event
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnCharacterSelect);
        }

        LoadState();
    }

    void OnCharacterSelect()
    {
        // Check if the character is unlocked (the locked image is not active)
        if (!lockedImage.gameObject.activeSelf)
        {
            SetMainPlayerRendererState(false); // Disable the main player's MeshRenderer and save the state

            // Disable and save the state of the previously active child GameObject
            if (currentlyActiveChild != null)
            {
                currentlyActiveChild.SetActive(false);
            }

            // Enable the selected child GameObject, update the currently active child, and save the state
            if (childToShow != null)
            {
                childToShow.SetActive(true);
                currentlyActiveChild = childToShow;
                PlayerPrefs.SetString(SelectedChildKey, childToShow.name); // Save the name of the active child
            }


            PlayerPrefs.Save(); // Ensure all changes are saved
        }
    }

    private void LoadState()
    {
        // Load and apply the main player's MeshRenderer state
        bool isRendererEnabled = PlayerPrefs.GetInt(MainPlayerRendererStateKey, 1) == 1; // Default to enabled
        SetMainPlayerRendererState(isRendererEnabled);

        // Load and activate the selected child GameObject
        string selectedChildName = PlayerPrefs.GetString(SelectedChildKey, string.Empty);
        if (!string.IsNullOrEmpty(selectedChildName))
        {
            foreach (Transform child in mainPlayer.transform)
            {
                if (child.name == selectedChildName)
                {
                    child.gameObject.SetActive(true);
                    currentlyActiveChild = child.gameObject;
                    break; // Stop the loop once the selected child is found and activated
                }
            }
        }
    }

    private void SetMainPlayerRendererState(bool isEnabled)
    {
        MeshRenderer meshRenderer = mainPlayer.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = isEnabled;
            PlayerPrefs.SetInt(MainPlayerRendererStateKey, isEnabled ? 1 : 0); // Save the state
        }
    }
}
