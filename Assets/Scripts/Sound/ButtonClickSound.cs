using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public Button[] buttons; // Array of buttons to trigger the sound
    public AudioClip clickSound; // Sound to be played when the button is clicked
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Iterate through each button in the array
        foreach (Button btn in buttons)
        {
            // Add a listener to the button that invokes the ClickSound method when clicked
            btn.onClick.AddListener(ClickSound);
        }
    }

    void ClickSound()
    {
        // Check if an audio clip is assigned
        if (clickSound != null)
        {
            // Play the assigned audio clip
            audioSource.PlayOneShot(clickSound);
        }
    }
}
