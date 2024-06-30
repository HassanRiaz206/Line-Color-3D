using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPanel : MonoBehaviour
{

    // Method to restart the entire game (return to the main menu or starting scene)
    public void RestartGame()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
