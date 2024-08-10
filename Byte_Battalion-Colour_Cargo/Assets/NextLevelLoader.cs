using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using MLabsSdk;

public class NextLevelLoader : MonoBehaviour
{
    public static bool isEndless;
    public static float levelCount = 12;
    public string nextLevel;
    public string[] Levels = new string[11] { "Level-2", "Level-3", "Level-4", "Level-5", "Level-6", "Level-7", "Level-8", "Level-9", "Level-10", "Level-11", "Level-12" };
    public int adloaderCount=0;
    public Text levelText;
    public PlayerPrefs adloaderCountStore;
    

    public string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    public string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd interstitialAd;
    
    public AnalyticsImp analyticsImp;
    private void Start()
    {
        adloaderCount = PlayerPrefs.GetInt("AdloaderCountStore", 0);
        nextLevel = SceneManager.GetActiveScene().name;
        UpdateLevelText();
        
        MobileAds.Initialize(initStatus => {
            LoadInterstitialAd();
        });
        //adloaderCount = PlayerPrefs.GetInt("AdloaderCount", 0);
        //nextLevelInterstitial = PlayerPrefs.GetString("NextLevelInterstitial", nextLevel);
        analyticsImp = FindObjectOfType<AnalyticsImp>();
    }
   

    void LoadBannerAd()
    {
        // Implement your banner ad loading logic if needed
    }

    void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        AdRequest request = new AdRequest();

        InterstitialAd.Load(interstitialAdUnitId, request,
          (InterstitialAd ad, LoadAdError error) =>
          {
              if (error != null || ad == null)
              {
                  Debug.LogError("interstitial ad failed to load an ad with error: " + error);
                  return;
              }

              Debug.Log("Interstitial ad loaded with response: " + ad.GetResponseInfo());
              interstitialAd = ad;
          });
    }

    public void NextLevel()
    {
        Debug.Log("value of adloadercount is "+adloaderCount);
        adloaderCount++;
        PlayerPrefs.SetInt("AdloaderCountStore", adloaderCount);
        PlayerPrefs.Save();
        if (!isEndless)
        {
            if (nextLevel == "Level-1")
            {
                nextLevel = "Level-2";
            }
            else if (nextLevel == "Level-2")
            {
                nextLevel = "Level-3";
            }
            else if (nextLevel == "Level-3")
            {
                nextLevel = "Level-4";
            }
            else if (nextLevel == "Level-4")
            {
                nextLevel = "Level-5";
            }
            else if (nextLevel == "Level-5")
            {
                nextLevel = "Level-6";
            }
            else if (nextLevel == "Level-6")
            {
                nextLevel = "Level-7";
            }
            else if (nextLevel == "Level-7")
            {
                nextLevel = "Level-8";
            }
            else if (nextLevel == "Level-8")
            {
                nextLevel = "Level-9";
            }
            else if (nextLevel == "Level-9")
            {
                nextLevel = "Level-10";
            }
            else if (nextLevel == "Level-10")
            {
                nextLevel = "Level-11";
            }
            else if (nextLevel == "Level-11")
            {
                nextLevel = "Level-12";
            }
            else if (nextLevel == "Level-12")
            {
                int RandomLevel = Random.Range(0, 10);
                nextLevel = Levels[RandomLevel];
                isEndless = true;
                levelCount += 1f;
            }
        }
        else if (isEndless)
        {
            int RandomLevel = Random.Range(0, 10);
            nextLevel = Levels[RandomLevel];
            levelCount += 1f;
            Debug.Log("NextLevel method called");
        }
        //PlayerPrefs.SetString("NextLevelInterstitial", nextLevel);
        //PlayerPrefs.Save();
        if (adloaderCount%2==0 && adloaderCount!=0) 
        {
            Debug.Log("in interstital");
            analyticsImp.LogAdMobInterstitialShown();
            //SceneManager.LoadScene("InterstitialAd");
            //LoadInterstitialAd();
            
            if (interstitialAd.CanShowAd())
            {
                interstitialAd.Show();
                interstitialAd.OnAdFullScreenContentClosed += () => { SceneManager.LoadScene(nextLevel);};
                //SceneManager.LoadScene(nextLevel);
            }
        }
        else
        {
            Debug.Log("in next level");
            UpdateLevelText();
            analyticsImp.LogEvent("Completed "+levelText);
            SceneManager.LoadScene(nextLevel);
        }
        //adloaderCount++;
        //PlayerPrefs.SetInt("AdloaderCount", adloaderCount);
        //PlayerPrefs.Save();
        //Debug.Log(adloaderCount);

    }
    //public void NextLevelInterstitial()
    //{
    //    Debug.Log("in next level interstitial");
        
    //    UpdateLevelText();
    //    SceneManager.LoadScene(PlayerPrefs.GetString("NextLevelInterstitial", nextLevel));
    //}
    
    

    

    void UpdateLevelText()
    {
        if (isEndless)
        {
            levelText.text = "Level-" + levelCount;
        }
        else
        {
            int levelNumber;
            if (int.TryParse(nextLevel.Replace("Level-", ""), out levelNumber))
            {
                if (levelText != null)
                {
                    levelText.text = "Level-" + levelNumber;
                }
            }
        }
    }
}
