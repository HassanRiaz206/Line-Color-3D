using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    public void ResetGame()
    {
        // Delete all player preferences
        PlayerPrefs.DeleteAll();

        // Load the first level scene
        SceneManager.LoadScene(0);
    }
}
