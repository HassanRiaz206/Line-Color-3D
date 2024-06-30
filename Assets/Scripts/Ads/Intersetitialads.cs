using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Intersetitialads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
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

    public void LoadInterstitalAd()
    {
        Advertisement.Load(adUnitId, this);
    }

public void ShowInterstitialAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadInterstitalAd();
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
      
    }
    #endregion

    #region loadCallBacks
    public void OnUnityAdsAdLoaded(string placementId)
    {
        
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }
    #endregion
}
