using PathCreation.Examples;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public PathFollower pathFollower;
    public EnemyController enemyController;
    public GameObject enemyObject;
    public GameObject followerObject;
    public DisableEnemy disableEnemy;
    void Start()
    {
        // Disable the PathFollower component, the EnemyController, and the enemy and follower game objects initially
        if (pathFollower != null)
        {
            pathFollower.enabled = false;
        }
        if (enemyController != null)
        {
            enemyController.enabled = false;
        }
        if (disableEnemy != null)
        { disableEnemy.enabled = false; }
        if (enemyObject != null)
        {
            enemyObject.SetActive(false);
        }
        if (followerObject != null)
        {
            followerObject.SetActive(false);
        }
    }

    public void OnTapToPlayButtonPressed()
    {
        // Activate the PathFollower component, the EnemyController, and the enemy and follower game objects when the button is pressed
        if (pathFollower != null)
        {
            pathFollower.enabled = true;
        }
        if (enemyController != null)
        {
            enemyController.enabled = true;
        }
        if (disableEnemy != null)
        {
            disableEnemy.enabled = true;
        }
        if (enemyObject != null)
        {
            enemyObject.SetActive(true);
        }
        if (followerObject != null)
        {
            followerObject.SetActive(true);
        }
    }
}
