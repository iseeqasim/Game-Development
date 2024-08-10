using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;


public class PlayScript : MonoBehaviour
{
    private BannerView bannerView;
    public string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    void Start()
    {
        bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    void OnDestroy()
    {
        bannerView.Destroy();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level-1");
    }
}
