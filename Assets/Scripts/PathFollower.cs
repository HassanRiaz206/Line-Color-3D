using UnityEngine;

namespace PathCreation.Examples
{
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float baseSpeed = 2f; // Adjust as needed
        private float currentSpeed; // To track the current speed
        public float distanceTravelled;

        void Start()
        {
            currentSpeed = baseSpeed; // Initialize the current speed
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Start moving only when touch begins
                    distanceTravelled += currentSpeed * Time.deltaTime;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    // Continue moving when touch is ongoing
                    distanceTravelled += currentSpeed * Time.deltaTime;
                }

                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        // OnTriggerEnter is called when the Collider other enters the trigger
        void OnTriggerEnter(Collider other)
        {
            // Check if the other collider is tagged as "1x"
            if (other.CompareTag("1x"))
            {
                Debug.Log("Triggered with object tagged as 1x");

                // Increase the speed by 1 unit
                currentSpeed += 1f;

                // Disable the game object "1x"
                other.gameObject.SetActive(false);
            }
        }
    }
}
