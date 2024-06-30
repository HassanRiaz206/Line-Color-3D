using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Reference to the Completed Panel
    public GameObject completedPanel;

    private void Start()
    {
        // Ensure the completed panel is disabled when the game starts
        if (completedPanel != null)
        {
            completedPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Show the completed panel
            if (completedPanel != null)
            {
                completedPanel.SetActive(true);
            }
            // Optionally, add any other logic here for when the checkpoint is reached.
            // For example, saving the game progress, playing a sound, etc.
        }
    }
}
