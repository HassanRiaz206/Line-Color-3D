using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    private int score = 0;
    private int highScore = 0;

    // Random number to be set in inspector
    public int randomScore;

    void Start()
    {
        // Load the high score from player prefs
        LoadHighScore();

        // Set the initial score
        score = randomScore;
        UpdateScoreText();
    }

    // Function to update the score text
    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    // Function to update the high score text
    void UpdateHighScoreText()
    {
        HighScoreText.text = highScore.ToString();
    }

    // Function to load the high score from player prefs
    void LoadHighScore()
    {
        // Load the high score from player prefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display the high score
        UpdateHighScoreText();
    }

    // Function to claim the points and save high score
    public void ClaimPointsAndSaveHighScore()
    {
        // Add the current score to the high score
        highScore += score;

        // Save the updated high score to player prefs
        PlayerPrefs.SetInt("HighScore", highScore);

        // Update the high score text
        UpdateHighScoreText();

        // Reset the score to 0 or any other initial value as needed
        score = 0;
        UpdateScoreText();
    }
}
