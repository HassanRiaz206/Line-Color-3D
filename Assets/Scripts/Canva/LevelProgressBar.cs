using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    public Image filledImage; // Reference to the filled image of the progress bar
    public Transform playerTransform; // Reference to the player's transform
    public Transform[] trackPoints; // Array of points defining the curvy path track

    private float totalDistance;
    private float currentPathLength = 0f;

    void Start()
    {
        // Calculate the total length of the track
        for (int i = 0; i < trackPoints.Length - 1; i++)
        {
            currentPathLength += Vector3.Distance(trackPoints[i].position, trackPoints[i + 1].position);
        }
    }

    void Update()
    {
        if (playerTransform != null && filledImage != null && trackPoints.Length > 1)
        {
            // Calculate the current length of the track covered by the player
            float playerPathLength = 0f;
            for (int i = 0; i < trackPoints.Length - 1; i++)
            {
                playerPathLength += Vector3.Distance(trackPoints[i].position, trackPoints[i + 1].position);
                if (Vector3.Distance(playerTransform.position, trackPoints[i + 1].position) < 0.1f)
                {
                    break;
                }
            }

            // Update the fill amount of the progress bar
            filledImage.fillAmount = Mathf.Clamp01(playerPathLength / currentPathLength);
        }
    }
}
