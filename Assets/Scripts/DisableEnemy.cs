using UnityEngine;
using UnityEngine.UI;

public class DisableEnemy : MonoBehaviour
{
    public GameObject enemyObject; // Reference to the enemy GameObject
    public float disableDuration = 1f; // Duration for which the enemy will be disabled
    public Button continueButton; // Reference to the continue button

    private const string EnemyDisabledKey = "EnemyDisabled";

    void Start()
    {
        // Check if the enemy should be disabled from PlayerPrefs
        if (PlayerPrefs.GetInt(EnemyDisabledKey, 0) == 1)
        {
            DisableEnemyObject();
        }

        // Assuming you have a UI button to continue, you can add an event listener here
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinueButtonClick);
        }
        else
        {
            Debug.LogError("Continue button reference not set!");
        }
    }

    void OnContinueButtonClick()
    {
        DisableEnemyObject();
        // Set a flag in PlayerPrefs indicating that the enemy should be disabled
        PlayerPrefs.SetInt(EnemyDisabledKey, 1);
    }

    void DisableEnemyObject()
    {
        enemyObject.SetActive(false); // Disable the enemy
        Invoke(nameof(EnableEnemyObject), disableDuration);
    }

    void EnableEnemyObject()
    {
        enemyObject.SetActive(true); // Re-enable the enemy
        // Remove the flag from PlayerPrefs
        PlayerPrefs.DeleteKey(EnemyDisabledKey);
    }
}
