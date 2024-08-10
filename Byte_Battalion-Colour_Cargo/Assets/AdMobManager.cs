using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AdMobManager : MonoBehaviour
{
    public string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    public string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    void Start()
    {
        // Initialize AdMob
        MobileAds.Initialize(initStatus =>
        {
            // Initialization completed. You can now load ads.
            Debug.Log("AdMob initialization status: " + initStatus.ToString());

            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                LoadBannerAd();
                LoadInterstitialAd();
            }
        });
    }
    
    

    void LoadBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }

    void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        AdRequest request = new AdRequest();
        InterstitialAd.Load(interstitialAdUnitId, request, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Interstitial ad failed to load an ad with error: " + error);
                return;
            }

            Debug.Log("Interstitial ad loaded with response: " + ad.GetResponseInfo());
            interstitialAd = ad;
        });
    }
    public void AdDestroy()
    {
        bannerView.Destroy();
    }
    public void Adhide()
    {
        Debug.Log("Adhide");
        bannerView.Hide();
    }
    public void Adshow()
    {
        Debug.Log("Adshow");
        LoadBannerAd();
    }
}
