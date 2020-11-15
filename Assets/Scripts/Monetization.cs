using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour
{
    // Start is called before the first frame update
    string GooglePlayID  = "3902621";
    bool testMode = true;
    void Start()
    {
        Advertisement.Initialize (GooglePlayID, testMode);
    }

    // Update is called once per frame
    public void ShowInterstitialAd() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        } 
        else {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
}
