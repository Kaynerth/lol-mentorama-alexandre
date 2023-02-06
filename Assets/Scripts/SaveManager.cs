using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public FullScreenChange fullScreenSettings;
    public ResolutionChange resolutionSettings;
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider musicSlider;

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("FullScreenSave", Convert.ToInt32(fullScreenSettings.GetComponent<Toggle>().isOn));
        PlayerPrefs.SetInt("ResolutionSave", resolutionSettings.resolutionDropdown.value);
        PlayerPrefs.SetFloat("MusicVolumeSave", musicSlider.value);
        PlayerPrefs.SetFloat("EffectsVolumeSave", effectsSlider.value);
    }
}
