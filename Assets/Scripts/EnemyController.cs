using UnityEngine;
using TMPro;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject enemyPrefab;
    public Transform playerTransform; // Assign the player's transform in the inspector
    public GameObject enemyPanel;
    private bool isScreenTouched = false;
    private float countdownTime = 5f;
    private float waitTime = 6f;
    [SerializeField] private AudioSource audioSource; // Attach the AudioSource component in the inspector

    // Define colors for the countdown gradient
    public Color startColor = Color.green;
    public Color endColor = Color.red;

    private void Start()
    {
        // Deactivate the enemy panel initially
        enemyPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isScreenTouched)
        {
            // Wait for 2 seconds before activating the enemy panel
            StartCoroutine(ActivateEnemyAfterDelay(waitTime));
        }

        // Start the countdown if the enemy panel is active and the screen is not touched
        if (enemyPanel.activeSelf && !isScreenTouched)
        {
            countdownTime -= Time.deltaTime;
            // Update the countdown text
            countdownText.text = Mathf.Ceil(countdownTime).ToString();

            // Change text color based on countdown value
            SetCountdownTextColor();

            // Stop the countdown if the screen is touched
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                isScreenTouched = true;
                ResetCountdown();
            }

            // If countdown reaches zero, spawn enemy and perform necessary actions
            if (countdownTime <= 0f)
            {
                // Spawn the enemy prefab
                SpawnEnemy();

                // Reset the countdown
                ResetCountdown();
            }
        }
    }

    private void ResetCountdown()
    {
        countdownTime = 5f;
        countdownText.text = "";

        // Reset the screen touched flag
        isScreenTouched = false;

        // Disable the script for 2 seconds
        StartCoroutine(DisableScriptForDelay(2f));
    }

    private IEnumerator DisableScriptForDelay(float delay)
    {
        // Disable the script
        this.enabled = false;

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Enable the script again
        this.enabled = true;
    }

    private IEnumerator ActivateEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyPanel.SetActive(true);
    }

    private void SetCountdownTextColor()
    {
        // Calculate the normalized progress of the countdown
        float normalizedProgress = countdownTime / 5f;

        // Interpolate between startColor and endColor based on the progress
        Color lerpedColor = Color.Lerp(endColor, startColor, normalizedProgress);

        // Assign the interpolated color to the countdown text
        countdownText.color = lerpedColor;
    }

    // Spawn the enemy prefab and set its target to follow the player
    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, Camera.main.transform.position, Quaternion.identity);
        EnemyFollowPlayer followScript = enemy.GetComponent<EnemyFollowPlayer>();
        if (followScript != null && playerTransform != null)
        {
            followScript.SetTarget(playerTransform);
        }

        // Play the rocket audio if the AudioSource component has been assigned
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    // Method to handle game over
    public void GameOver()
    {
        // Deactivate the enemy panel
        enemyPanel.SetActive(false);

        // Disable the script
        this.enabled = false;
    }
}
