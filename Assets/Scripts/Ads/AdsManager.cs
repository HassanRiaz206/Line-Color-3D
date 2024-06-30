using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public Bannerads bannerads;
    public Intersetitialads intersetitialads;
    public initializeads initializeads;
    public Rewardedads rewardedads;

    public static AdsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        bannerads.LoadBannerAd();
        intersetitialads.LoadInterstitalAd();
        rewardedads.LoadRewardedAd();
    }

   


}
