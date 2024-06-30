using UnityEngine;
using TMPro;
using System.Collections;

using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coinTextMeshPro;
    public TextMeshProUGUI totalCoinsTextMeshPro;
    public TextMeshProUGUI claimTextMeshPro;

    private int score = 0;
    public int totalCoins = 0;
    public string totalCoinsPlayerPrefsKey = "TotalCoins";

    public int buttonPressCount = 0;

    private const string ButtonPressCountKey = "ButtonPressCount";
    public bool isRewarded = false;
    public bool isReward = false;

    public static Coin Instance { get; private set; }

    void Start()
    {
        LoadTotalCoins();
        UpdateTotalCoinsDisplay();
        StartCoroutine(DisplayBannerWithDelay());

        buttonPressCount = PlayerPrefs.GetInt(ButtonPressCountKey, 0);
    }
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
    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerads.ShowBannerAd();
    }
    public void CollectCoin()
    {
        score++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (coinTextMeshPro != null)
        {
            coinTextMeshPro.text = score.ToString();
        }
    }

    private void LoadTotalCoins()
    {
        if (PlayerPrefs.HasKey(totalCoinsPlayerPrefsKey))
        {
            totalCoins = PlayerPrefs.GetInt(totalCoinsPlayerPrefsKey);
        }
    }

    public void UpdateTotalCoinsDisplay() // Changed access modifier to public
    {
        if (totalCoinsTextMeshPro != null)
        {
            totalCoinsTextMeshPro.text = totalCoins.ToString();
        }
    }
    public void TransferCoinsAndSave()
    {
        if (coinTextMeshPro != null && totalCoinsTextMeshPro != null)
        {
            int coinsToAdd = int.Parse(coinTextMeshPro.text); // Get the number of coins displayed
            totalCoins += coinsToAdd; // Add the coins to the total coins
            PlayerPrefs.SetInt(totalCoinsPlayerPrefsKey, totalCoins); // Save total coins to PlayerPrefs
            PlayerPrefs.Save(); // Ensure PlayerPrefs changes are saved
            UpdateTotalCoinsDisplay(); // Update the total coins display
            coinTextMeshPro.text = "0"; // Reset the coins displayed in the coinTextMeshPro
        }
    }


    public void OnClaimButtonPressed()
    {
        if (claimTextMeshPro != null)
        {
            int claimScore = int.Parse(claimTextMeshPro.text);
            totalCoins += claimScore;
            PlayerPrefs.SetInt(totalCoinsPlayerPrefsKey, totalCoins);
            PlayerPrefs.Save();
            UpdateTotalCoinsDisplay();
            claimTextMeshPro.text = "0";

            // Check if the buttonPressCount is divisible by 3 and greater than 0
            if (buttonPressCount % 2 == 0 && buttonPressCount > 0)
            {
                AdsManager.Instance.intersetitialads.ShowInterstitialAd();
            }

            // Increment buttonPressCount and save it to PlayerPrefs
            buttonPressCount++;
            if (buttonPressCount >= 4) // Reset buttonPressCount to 0 if it reaches 4
            {
                buttonPressCount = 0;
            }
            PlayerPrefs.SetInt(ButtonPressCountKey, buttonPressCount);
        }
    }
    public void threeX()
    {
        AdsManager.Instance.bannerads.HideBannerAd();

        AdsManager.Instance.rewardedads.ShowRewardedAd();
    }
    public void TripleAndClaimCoins()
    {

        if (isReward)
        {
            int currentClaimScore;
            if (int.TryParse(claimTextMeshPro.text, out currentClaimScore))
            {
                // Parsing successful, continue with the logic
                int newClaimScore = currentClaimScore * 3;
                totalCoins += newClaimScore;
                PlayerPrefs.SetInt(totalCoinsPlayerPrefsKey, totalCoins);
                PlayerPrefs.Save();
                UpdateTotalCoinsDisplay();
                claimTextMeshPro.text = newClaimScore.ToString();
                RestartGame();
            }
            }
        else
        {
            Debug.Log("Ads not watched");
        }
    }



    public void OnNoThanksButtonPressed()
    {
        if (coinTextMeshPro != null && claimTextMeshPro != null)
        {
            int currentScore = int.Parse(coinTextMeshPro.text);
            AdsManager.Instance.bannerads.HideBannerAd();

            if (buttonPressCount % 3 == 0 && buttonPressCount > 0) // Only show ad if buttonPressCount is divisible by 3 and greater than 0
            {
                AdsManager.Instance.intersetitialads.ShowInterstitialAd();
            }

            if (currentScore > 0)
            {
                claimTextMeshPro.text = "+" + currentScore.ToString();
                score = 0;
                UpdateScoreDisplay();
            }
            else
            {
                RestartGame();
                AdsManager.Instance.bannerads.HideBannerAd();
                if (buttonPressCount % 3 == 0 && buttonPressCount > 0) // Show ad after restarting the game
                {
                    AdsManager.Instance.intersetitialads.ShowInterstitialAd();
                }
            }
        }
    }

    public void UseCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            PlayerPrefs.SetInt(totalCoinsPlayerPrefsKey, totalCoins);
            PlayerPrefs.Save();
            UpdateTotalCoinsDisplay();
        }
    }


    public void RestartGame()
    {
        buttonPressCount++;
        if (buttonPressCount >= 4) // Reset buttonPressCount to 0 if it reaches 4
        {
            buttonPressCount = 0;
        }
        PlayerPrefs.SetInt(ButtonPressCountKey, buttonPressCount); // Save the button press count
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AdsManager.Instance.bannerads.ShowBannerAd();
    }
}
