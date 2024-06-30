using UnityEngine;

public class mainCameraFollower : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float heightAbovePlayer = 3f; // Height above the player
    public float distanceBehindPlayer = 5f; // Distance behind the player
    public float smoothSpeed = 0.125f; // How smoothly the camera catches up to its target position

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the target position of the camera
            Vector3 desiredPosition = player.position - player.forward * distanceBehindPlayer + Vector3.up * heightAbovePlayer;

            // Smoothly interpolate between the camera's current position and its target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Assign the smoothed position to the camera's transform
            transform.position = smoothedPosition;

            // Make the camera look at the player's position
            transform.LookAt(player.position);
        }
    }
}
