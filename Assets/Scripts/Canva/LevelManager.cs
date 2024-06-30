using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex; // Track the current scene index
    private int completedLevelIndex; // Track the completed level index

    void Start()
    {
        // Get the current scene index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if there is a completed level saved
        if (PlayerPrefs.HasKey("CompletedLevel"))
        {
            // Retrieve the completed level index
            completedLevelIndex = PlayerPrefs.GetInt("CompletedLevel");

            // Check if the completed level is the current scene
            if (completedLevelIndex == currentSceneIndex)
            {
                // Load the next scene
                LoadNextScene();
            }
        }
    }

    public void ClaimButtonPressed()
    {
        // Save the completed level
        PlayerPrefs.SetInt("CompletedLevel", currentSceneIndex);

        // Load the next level scene
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if there is a next level available
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No next level available. Game completed!");
            // Add logic here for what happens when the game is completed
        }
    }
}
