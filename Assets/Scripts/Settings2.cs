using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings2 : MonoBehaviour
{
    int qualityIndex;
    public void Start()
    {
        if(PlayerPrefs.HasKey("SavedGameQuailty"))
        {
           qualityIndex=PlayerPrefs.GetInt("SavedGameQuailty");
           QualitySettings.SetQualityLevel(qualityIndex);
        }
        else
        {
            QualitySettings.SetQualityLevel(3);
        }
    }
    // public List<ResItem> resolutions=new List<ResItem>();
    // private int selectedResolution;
    // public TMP_Text resolutionLabel;

    // Start is called before the first frame update
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen=isFullscreen;
    }

    public void UnSetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen=isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("SavedGameQuailty",qualityIndex);
        PlayerPrefs.Save();
    }

    public void SetVSyncTrue()
    {
        QualitySettings.vSyncCount=1;
    }

    public void SetVSyncFalse()
    {
        QualitySettings.vSyncCount=0;
    }

    // public void ResLeft()
    // {
    //     selectedResolution--;
    //     if(selectedResolution<0)
    //     {
    //         selectedResolution=0;
    //     }
    //     UpdateResLabel();
    // }

    // public void ResRight()
    // {
    //     selectedResolution++;
    //     if(selectedResolution>resolutions.Count-1)
    //     {
    //         selectedResolution=resolutions.Count-1;
    //     }
    //     UpdateResLabel();
    // }

    // public void UpdateResLabel
    // {
    //     resolutionLabel.text = resolutions[selectedResolution.horizontal].ToString()+"x"+resolutions[selectedResolution.vertical].ToString();
    // }

    // [System.Serializable]
    // public class ResItem
    // {
    //     public int horizontal, vertical;
    // }

    public void SetScreenHD()
    {
        Screen.SetResolution(1920,1080,Screen.fullScreen);
    }

    public void SetScreen720()
    {
        Screen.SetResolution(1280,720,Screen.fullScreen);
    }

    public void SetScreen854()
    {
        Screen.SetResolution(854,480,Screen.fullScreen);
    }
}
