using UnityEngine;

namespace PathCreation.Examples
{
    public class ResetDistance : MonoBehaviour
    {
        private const string DistanceKey = "DistanceTraveled";

        // Function to reset the distance traveled to zero in PlayerPrefs
        public void ResetDistanceTraveled()
        {
            PlayerPrefs.SetFloat(DistanceKey, 0f);
            PlayerPrefs.Save();
        }
    }
}
