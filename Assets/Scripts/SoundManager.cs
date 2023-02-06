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
            musicAudioSource.volume = PlayerPrefs.GetFloat("MusicVolumeSave");
            audioSource.volume = PlayerPrefs.GetFloat("EffectsVolumeSave");
        }

        else
        {
            audioSource.volume = effectsSlider.value;
            musicAudioSource.volume = musicSlider.value;
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolumeSave");
            effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolumeSave");
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
