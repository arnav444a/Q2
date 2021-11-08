using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAdController : MonoBehaviour
{
    public float totalDeaths = 0f;
    AdsController adsController;
    private void Awake()
    {
        adsController = FindObjectOfType<AdsController>();
    }
    public void AddDeath()
    {
        totalDeaths += 1f;
        if (totalDeaths %7f==0)
        {
            adsController.ShowInterstitialAd();
        }
    }
}
