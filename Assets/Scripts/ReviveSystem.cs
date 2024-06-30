using UnityEngine;
using UnityEngine.SceneManagement;

namespace PathCreation.Examples
{
    public class ReviveSystem : MonoBehaviour
    {
        private const string DistanceKey = "DistanceTraveled";
        public bool isWatched = false;
        public static ReviveSystem Instance { get; private set; }

        private void Awake()
        {
            // Ensure only one instance of Coin exists
            if (Instance == null)
            {
                // Set the instance to this object if it's null
                Instance = this;
            }
            else
            {
                // If another instance already exists, destroy this one
                Destroy(gameObject);
            }
        }

        private void SaveDistance(float distance)
        {
            PlayerPrefs.SetFloat(DistanceKey, distance);
            PlayerPrefs.Save();
        }

        private float LoadDistance()
        {
            return PlayerPrefs.GetFloat(DistanceKey, 0f);
        }

        public void RestartGame()
        {
            SaveDistance(GetComponent<PathFollower>().distanceTravelled);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void Start()
        {
            float savedDistance = LoadDistance();
            PathFollower pathFollower = GetComponent<PathFollower>();

            if (pathFollower != null && pathFollower.pathCreator != null)
            {
                pathFollower.distanceTravelled = savedDistance;
                transform.position = pathFollower.pathCreator.path.GetPointAtDistance(savedDistance, pathFollower.endOfPathInstruction);
                transform.rotation = pathFollower.pathCreator.path.GetRotationAtDistance(savedDistance, pathFollower.endOfPathInstruction);
            }
        }

        public void ContinueButtonPressed()
        {
            // Assuming AdsManager is correctly set up and operational
            AdsManager.Instance.bannerads.HideBannerAd();
            AdsManager.Instance.rewardedads.ShowRewardedAd();
        }

        // This method could be called directly by the ad completion callback
        public void OnAdWatched()
        {
            isWatched = true;
            gameRevive();
        }

        public void gameRevive()
        {
            if (isWatched)
            {
                RestartGame();
            }
            else
            {
                Debug.Log("Ad not watched - game not revived");
            }
        }
    }
}
