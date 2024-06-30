using UnityEngine;

public class RotatingEnemy4hand : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the rotation speed as needed

    void Update()
    {
        // Rotate the GameObject around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
