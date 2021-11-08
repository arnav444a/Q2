using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour, IUnityAdsListener
{
    private string store_id = "3983069";
    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(store_id, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAds()
    {
        if (Advertisement.IsReady(video_ad))
        {
            
            Advertisement.Show(video_ad);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        ///throw new System.NotImplementedException();
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewarded_video_ad)
                {

                }
                break;
        }
    }
}
