using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Rewardedads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
         adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#endif

    }
    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadRewardedAd();
    }


 


    #region ShowCallBacks


    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Ads fully watched...");

            // Set isRewarded to true
            Coin.Instance.isRewarded = true;
            // Restart the game
            Coin.Instance.isReward= true;
            // Call TripleAndClaimCoins method to triple the claim score and add it to total coins
            Coin.Instance.TripleAndClaimCoins();


            ReviveSystem.Instance.isWatched = true;
            ReviveSystem.Instance.gameRevive();
        }
    }


    #endregion

    #region loadCallBacks
    public void OnUnityAdsAdLoaded(string placementId)
    {

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Coin.Instance.isRewarded = false;
        Debug.Log("Failed ads reward");
    }
    #endregion
}
