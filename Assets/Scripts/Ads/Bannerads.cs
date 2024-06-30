using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Bannerads : MonoBehaviour
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

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }
    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            clickCallback = Bannerclicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();

    }
        #region ShowCallBack
        private void Bannerclicked()
    {
        throw new NotImplementedException();
    }

    private void BannerHidden()
    {
        Debug.Log("Banner is hide");
    }

    private void BannerShown()
    {
        Debug.Log("Banner ad show");
    }
    #endregion
    #region LocalCallBack
    private void BannerLoadedError(string message)
    {
        throw new NotImplementedException();
    }

    private void BannerLoaded()
    {
        Debug.Log("Banner ad load");
    }
    #endregion
}