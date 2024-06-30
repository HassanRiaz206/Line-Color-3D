using PathCreation.Examples;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject chest; // Assign the Chest GameObject in the Inspector
    public PathFollower pathFollower; // Assign the player's PathFollower script in the Inspector
    public float moveSpeed = 5f; // Speed at which the player moves towards the chest

    private GameObject player; // To keep reference to the player
    private bool playerWon = false;

    void OnTriggerEnter(Collider other) // Changed from OnCollisionEnter to OnTriggerEnter
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerWins(other.gameObject);
        }
    }

    void PlayerWins(GameObject playerObject)
    {
        Debug.Log("Player Wins!");

        // Disable the PathFollower script
        if (pathFollower != null)
        {
            pathFollower.enabled = false;
        }

        // Stop the player's movement immediately by setting velocity to zero, if using a Rigidbody
        Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
        }

        // Alternatively, if the player movement is controlled by another script, disable that script:
        // playerObject.GetComponent<OtherMovementScript>().enabled = false;

        // Set the player reference and indicate that the player has won
        player = playerObject;
        playerWon = true;
    }

    void Update()
    {
        if (playerWon)
        {
            MovePlayerTowardsChest();
        }
    }

    void MovePlayerTowardsChest()
    {
        if (player != null && chest != null)
        {
            // Move the player towards the chest
            Vector3 direction = (chest.transform.position - player.transform.position).normalized;
            player.transform.position += direction * moveSpeed * Time.deltaTime;

            // Optional: Make the player face the chest
            player.transform.LookAt(chest.transform);

            // Once the player reaches the chest, stop the movement
            if (Vector3.Distance(player.transform.position, chest.transform.position) < 0.1f)
            {
                // Stop the player's forward movement
                playerWon = false; // This will stop calling MovePlayerTowardsChest in Update

                // If you're using a Rigidbody and want to stop any physics-based movement, do it here as well
                // playerRigidbody.velocity = Vector3.zero;
            }
        }
    }
}
