using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the TextMeshPro namespace

public class CharacterSelectButton : MonoBehaviour
{
    public GameObject characterToShow; // Assign the corresponding character GameObject in the inspector
    public TextMeshProUGUI priceText; // Assign your TextMeshProUGUI component in the inspector
    public Image lockedImage; // Assign the UI Image that indicates the character is locked
    public int characterPrice; // Set this price for each character in the inspector
    public Coin coinScript; // Assign the Coin script object in the inspector
    private string characterPurchasedKey; // Key used for saving the purchase status

    // Static reference to track the currently selected button
    private static CharacterSelectButton currentSelectedButton;

    private void Start()
    {
        // Ensure the button has a listener for the click event
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnCharacterSelect);
        }

        // Initialize PlayerPrefs key with a unique identifier for this character
        characterPurchasedKey = "CharacterPurchased_" + gameObject.name;

        // Check if the character has already been purchased
        if (PlayerPrefs.GetInt(characterPurchasedKey, 0) == 1)
        {
            UnlockCharacter();
            priceText.enabled = false; // Disable price text if character already purchased
        }
        else
        {
            // Ensure that the price text is enabled for characters not yet purchased
            priceText.enabled = true;
        }
    }

    void OnCharacterSelect()
    {
        // Disable the previously selected character
        if (currentSelectedButton != null && currentSelectedButton.characterToShow != characterToShow)
        {
            currentSelectedButton.characterToShow.SetActive(false);
        }

        // Enable the selected character only if it is unlocked
        if (characterToShow != null && lockedImage != null && !lockedImage.gameObject.activeSelf)
        {
            characterToShow.SetActive(true);
        }
        else
        {
            // Optionally, handle the case where the character is locked/not available for selection
            characterToShow.SetActive(false);
        }

        // Check purchase status and update priceText accordingly
        // Ensure priceText is enabled before attempting to update its text
        priceText.enabled = true; // Add this line

        if (PlayerPrefs.GetInt(characterPurchasedKey, 0) == 1)
        {
            // For purchased characters, display "Play" symbol or text
            priceText.text = "Play"; // Or simply "▶︎"
        }
        else
        {
            // For characters not yet purchased, display their price
            priceText.text = characterPrice.ToString() ;
        }

        currentSelectedButton = this;
    }

    public static void TryUnlockSelectedCharacter()
    {
        if (currentSelectedButton != null)
        {
            currentSelectedButton.TryUnlockCharacter();
        }
    }

    private void TryUnlockCharacter()
    {
        if (coinScript.totalCoins >= characterPrice)
        {
            coinScript.UseCoins(characterPrice);
            PlayerPrefs.SetInt(characterPurchasedKey, 1); // Mark the character as purchased
            PlayerPrefs.Save();

            UnlockCharacter();
            priceText.enabled = false; // Disable price text after purchase
            characterToShow.SetActive(true); // Ensure the character is shown once unlocked
        }
        else
        {
            Debug.Log("Not enough coins to unlock this character.");
            // Optionally, provide feedback to the player that they don't have enough coins
        }
    }

    private void UnlockCharacter()
    {
        if (lockedImage != null)
        {
            lockedImage.gameObject.SetActive(false); // Assuming lockedImage indicates character is locked
        }
        // Additional code to handle the character being permanently unlocked
    }
}
