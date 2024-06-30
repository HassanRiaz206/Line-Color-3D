using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Transform target; // The target to follow (player's transform)
    public float moveSpeed = 3f; // The speed at which the enemy moves

    // Set the target to follow
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        // Check if the target is set and valid
        if (target != null)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the movement amount based on the speed and frame rate
            float movementAmount = moveSpeed * Time.deltaTime;

            // Move towards the target
            transform.position += direction * movementAmount;
        }
    }
}
