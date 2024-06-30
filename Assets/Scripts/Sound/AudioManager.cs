using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioListener audioListener;
    private bool isAudioListenerEnabled = true;
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;
    private Image buttonImage;

    void Start()
    {
        // Get the AudioListener component attached to the main camera
        audioListener = Camera.main.GetComponent<AudioListener>();

        if (audioListener == null)
        {
            Debug.LogError("AudioListener component not found on the Main Camera.");
        }

        // Check PlayerPrefs for the saved state of the AudioListener
        isAudioListenerEnabled = PlayerPrefs.GetInt("AudioListenerEnabled", 1) == 1;

        // Set the AudioListener state
        audioListener.enabled = isAudioListenerEnabled;

        // Get the Image component of the button
        buttonImage = GetComponent<Image>();

        // Set the initial button image based on the AudioListener state
        if (buttonImage != null)
        {
            buttonImage.sprite = isAudioListenerEnabled ? audioOnSprite : audioOffSprite;
        }
        else
        {
            Debug.LogError("Image component not found on the button.");
        }
    }

    public void OnButtonPress()
    {
        if (audioListener != null)
        {
            // Toggle the AudioListener state
            isAudioListenerEnabled = !isAudioListenerEnabled;
            audioListener.enabled = isAudioListenerEnabled;

            // Save the state to PlayerPrefs
            PlayerPrefs.SetInt("AudioListenerEnabled", isAudioListenerEnabled ? 1 : 0);
            PlayerPrefs.Save();

            // Change the button image based on the AudioListener state
            if (buttonImage != null)
            {
                buttonImage.sprite = isAudioListenerEnabled ? audioOnSprite : audioOffSprite;
            }
            else
            {
                Debug.LogError("Image component not found on the button.");
            }

            Debug.Log("AudioListener " + (isAudioListenerEnabled ? "enabled" : "disabled"));
        }
        else
        {
            Debug.LogError("AudioListener component is null.");
        }
    }
}