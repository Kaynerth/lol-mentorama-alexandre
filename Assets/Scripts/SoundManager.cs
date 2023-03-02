using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip onClickSound;
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] AudioSource musicAudioSource;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene" || SceneManager.GetActiveScene().name == "EndGameScene")
        {
            musicAudioSource.volume = PlayerPrefs.GetFloat("MusicVolumeSave", 0.5f);
            audioSource.volume = PlayerPrefs.GetFloat("EffectsVolumeSave", 0.5f);
        }

        else
        {
            audioSource.volume = effectsSlider.value;
            musicAudioSource.volume = musicSlider.value;
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolumeSave", 0.5f);
            effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolumeSave", 0.5f);
        }
    }

    public void OnHoverButton()
    {
        audioSource.PlayOneShot(onClickSound);
    }

    public void EffectsSlider()
    {
        audioSource.volume = effectsSlider.value;
    }

    public void MusicSlider()
    {
        musicAudioSource.volume = musicSlider.value;
    }
}
