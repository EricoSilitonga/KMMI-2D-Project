using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour,IUnityAdsListener
{
#if UNITY_IOS
private string gameID = "4302582";
#elif UNITY_ANDROID
private string gameID = "4302583";
#elif UNITY_EDITOR
private string gameID = "4302583";
#endif

    private string placementId = "Rewarded_Android";

    public static AdManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAd()
    {
        Advertisement.Show(placementId);
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {

        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Banner");
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        //rubah jadi false sebelom finalisasi
        Advertisement.Initialize(gameID,false);
    }

    public void OnShowAdButton()
    {
        AdManager.instance.PlayAd();
    }
}
