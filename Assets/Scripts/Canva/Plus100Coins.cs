using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus100Coins : MonoBehaviour
{
    // Reference to the Coin class or instance
    public Coin coinInstance;

    // Key for PlayerPrefs
    public string totalCoinsPlayerPrefsKey = "TotalCoins";


    // Function to add 100 coins when +100 button is pressed
    public void plus100coins()
    {
        AdsManager.Instance.bannerads.HideBannerAd();

        AdsManager.Instance.rewardedads.ShowRewardedAd();

        // Start a coroutine to check for rewarded status and add coins
        StartCoroutine(WaitForRewardAndAddCoins());
    }

    
    IEnumerator WaitForRewardAndAddCoins()
    {

        // Wait until the rewarded status is updated
        while (!coinInstance.isRewarded)
        {
            yield return null; // Wait for the next frame
        }

        // Add 100 coins and save to PlayerPrefs
        coinInstance.totalCoins += 100;
        PlayerPrefs.SetInt(totalCoinsPlayerPrefsKey, coinInstance.totalCoins);
        PlayerPrefs.Save();
        Coin.Instance.RestartGame();

        coinInstance.isRewarded = false; // Reset rewarded status
        Debug.Log("100 coins added.");
    }

   
    
}