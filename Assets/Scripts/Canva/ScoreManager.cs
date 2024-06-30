using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace PathCreation.Examples
{
    public class ScoreManager : MonoBehaviour
    {
        public PathFollower pathFollower; // Reference to the PathFollower script
        public TextMeshProUGUI scoreText; // Reference to the TextMeshPro object to display the score
        public TextMeshProUGUI highScoreText; // Reference to the TextMeshPro object to display the high score
        public Image image1;
        public Image image2;
        public Image image3;
        public Image image4;
        public Image image5;

        private float score = 0f; // Current score
        private float highScore = 0f; // High score


        void Start()
        {
            // Load the high score from player preferences
            highScore = PlayerPrefs.GetFloat("HighScore", 0f);
            UpdateHighScoreText();

        }


        void Update()
        {
            if (pathFollower != null)
            {
                // Calculate score based on the distance travelled by the player
                score = pathFollower.distanceTravelled;

                // Update the score text
                UpdateScoreText();

                // Update the high score if the current score is greater
                if (score > highScore)
                {
                    highScore = score;
                    PlayerPrefs.SetFloat("HighScore", highScore);
                    PlayerPrefs.Save();
                    UpdateHighScoreText();
                }

                // Update the images based on the score
                UpdateImagesBasedOnScore();
            }
        }

        // Update the score text
        void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString("F0"); // Display the score without decimal points
            }
        }

        // Update the high score text
        void UpdateHighScoreText()
        {
            if (highScoreText != null)
            {
                highScoreText.text = highScore.ToString("F0"); // Display the high score without decimal points
            }
        }

        // Update the images based on the score
        void UpdateImagesBasedOnScore()
        {
            if (highScore < 100)
            {
                ShowImage(image1);
            }
            else if (highScore >= 100 && highScore < 200)
            {
                ShowImage(image2);
            }
            else if (highScore >= 200 && highScore < 300)
            {
                ShowImage(image3);
            }
            else if (highScore >= 300 && highScore < 400)
            {
                ShowImage(image4);
            }
            else
            {
                ShowImage(image5);
            }
        }

        // Helper method to show only the specified image and hide others
        void ShowImage(Image targetImage)
        {
            image1.enabled = targetImage == image1;
            image2.enabled = targetImage == image2;
            image3.enabled = targetImage == image3;
            image4.enabled = targetImage == image4;
            image5.enabled = targetImage == image5;
        }
    }
}
