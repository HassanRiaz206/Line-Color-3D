using PathCreation.Examples;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioSource audioSource; // Assign the audio source GameObject in the inspector
    private PathFollower pathFollowerScript; // Reference to the PathFollower script

    void Start()
    {
        // Get the reference to the PathFollower script attached to the GameObject
        pathFollowerScript = GetComponent<PathFollower>();

        // Ensure that the audio source is initially disabled
        audioSource.enabled = false;
    }

    void Update()
    {
        // Check if the PathFollower script is enabled
        if (pathFollowerScript.enabled)
        {
            // Enable the audio source if the script is enabled
            if (!audioSource.enabled)
            {
                audioSource.enabled = true;
                audioSource.Play(); // Start playing the audio clip
            }
        }
        else
        {
            // Disable the audio source if the script is disabled
            if (audioSource.enabled)
            {
                audioSource.enabled = false;
                audioSource.Stop(); // Stop playing the audio clip
            }
        }
    }
}
