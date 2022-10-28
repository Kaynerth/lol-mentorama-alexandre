using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public FullScreenChange fullScreenSettings;
    public ResolutionChange resolutionSettings;

    private void Start()
    {
        fullScreenSettings.GetComponent<Toggle>().isOn = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenSave"));
        resolutionSettings.resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionSave");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("FullScreenSave", Convert.ToInt32(fullScreenSettings.GetComponent<Toggle>().isOn));
        PlayerPrefs.SetInt("ResolutionSave", resolutionSettings.resolutionDropdown.value);
    }
}
