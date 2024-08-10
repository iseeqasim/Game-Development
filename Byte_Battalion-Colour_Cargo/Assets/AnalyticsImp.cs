using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

namespace MLabsSdk
{
    public class AnalyticsImp : MonoBehaviour
    {
        private bool isFirebaseInitialized = false;

        void Start()
        {
            // Initialize Firebase
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                isFirebaseInitialized = app != null;

                if (isFirebaseInitialized)
                {
                    Debug.Log("Firebase initialized successfully.");
                }
                else
                {
                    Debug.LogError("Firebase initialization failed.");
                }
            });
        }

        public void LogEvent(string eventName)
        {
            if (isFirebaseInitialized)
            {
                MLogs(eventName);
                FirebaseAnalytics.LogEvent(eventName);
            }
            else
            {
                MLogs("Firebase not initialized");
            }
        }

        public void LogEvent(string eventName, string paramName, int paramValue)
        {
            if (isFirebaseInitialized)
            {
                MLogs(eventName + " : " + paramName + " : " + paramValue);
                Parameter myparams = new Parameter(paramName, paramValue);
                FirebaseAnalytics.LogEvent(eventName, myparams);
            }
            else
            {
                MLogs("Firebase not initialized");
            }
        }

        void MLogs(string log)
        {
            Debug.Log("## " + log);
        }
        public void LogAdMobBannerShown()
        {
            LogEvent("AdMob_Banner_Shown");
        }

        public void LogAdMobInterstitialShown()
        {
            LogEvent("AdMob_Interstitial_Shown");
        }
    }
}