using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcube : MonoBehaviour
{
    public Transform target; // Empty GameObject to move towards
    public float moveSpeed = 5f; // Speed of the object's movement

    private Vector3 initialPosition; // Initial position of the object
    private bool movingTowardsTarget = true; // Flag to track the direction of movement

    void Start()
    {
        initialPosition = transform.position; // Store the initial position of the object
    }

    void Update()
    {
        if (movingTowardsTarget)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Check if the object has reached the target
            if (transform.position == target.position)
            {
                movingTowardsTarget = false; // Change the direction of movement
            }
        }
        else
        {
            // Move back to the initial position
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            // Check if the object has reached its initial position
            if (transform.position == initialPosition)
            {
                movingTowardsTarget = true; // Change the direction of movement
            }
        }
    }
}