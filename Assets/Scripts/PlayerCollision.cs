using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int coinScore = 0;

    public GameObject gameEndMenu;
    public DisableObjectsOnCollision disableObjectsScript;

    private bool isGameOver = false;

    public AudioSource playerAudioSource;
    public AudioSource deathAudioSource; // New audio source for death sound
    public AudioClip coinSound;
    public AudioClip deathSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Assuming the player is "dead" after collision with the enemy
            PlayerDeath();

            // Call the DisableObjects() method from DisableObjectsOnCollision script
            if (disableObjectsScript != null)
            {
                disableObjectsScript.DisableObjects();
            }
            else
            {
                Debug.LogError("DisableObjectsOnCollision script is not assigned in the Inspector");
            }
        }
    }

    void PlayerDeath()
    {
        // Play the death sound
        if (deathAudioSource != null && deathSound != null)
        {
            deathAudioSource.PlayOneShot(deathSound);
        }

        // Deactivate the player object after a short delay
        StartCoroutine(DisablePlayerAfterDelay());

        // Set the game over flag to true
        isGameOver = true;

        // Display the game end menu
        if (gameEndMenu != null)
        {
            gameEndMenu.SetActive(true);
        }
        else
        {
            Debug.LogError("Game end menu GameObject is not assigned in the Inspector");
        }

        // Optionally, stop game time
        // Time.timeScale = 0f;

        // Any other game end logic can go here
        // For example, save the game state, show scores, etc.
    }

    IEnumerator DisablePlayerAfterDelay()
    {
        // Wait for a short delay before deactivating the player
        yield return new WaitForSeconds(0.5f);

        // Deactivate the player object or perform any other needed death logic
        gameObject.SetActive(false);

        // Call the DisableObjects() method from DisableObjectsOnCollision script
        if (disableObjectsScript != null)
        {
            disableObjectsScript.DisableObjects();
        }
        else
        {
            Debug.LogError("DisableObjectsOnCollision script is not assigned in the Inspector");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Increment score
            coinScore++;

            // Update the TextMeshPro text with the score
            if (scoreText != null)
            {
                scoreText.text = coinScore.ToString();
            }

            // Play the coin sound
            if (playerAudioSource != null && coinSound != null)
            {
                playerAudioSource.PlayOneShot(coinSound);
            }

            // Deactivate the collected coin
            other.gameObject.SetActive(false);
        }
    }

    // Method to check if the game is over
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
