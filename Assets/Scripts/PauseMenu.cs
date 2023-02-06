using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;

    [SerializeField] Image pauseMenuText;
    [SerializeField] Image pauseMenuImage;
    [SerializeField] Image pauseMenuPanel;
    [SerializeField] Image pauseMenuBackground;
    [SerializeField] Image pauseMenuMusic;
    [SerializeField] Image pauseMenuEffects;
    [SerializeField] Button pauseMenuBack;
    [SerializeField] Slider pauseMusicSlider;
    [SerializeField] Slider pauseEffectsSlider;

    private void Start()
    {
        pauseMenuText.gameObject.SetActive(false);
        pauseMenuImage.gameObject.SetActive(false);
        pauseMenuPanel.gameObject.SetActive(false);
        pauseMenuBackground.gameObject.SetActive(false);
        pauseMenuMusic.gameObject.SetActive(false);
        pauseMenuEffects.gameObject.SetActive(false);
        pauseMenuBack.gameObject.SetActive(false);
        pauseMusicSlider.gameObject.SetActive(false);
        pauseEffectsSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPaused == false)
        {
            Time.timeScale = 0;

            pauseMenuText.gameObject.SetActive(true);
            pauseMenuImage.gameObject.SetActive(true);
            pauseMenuPanel.gameObject.SetActive(true);
            pauseMenuBackground.gameObject.SetActive(true);
            pauseMenuMusic.gameObject.SetActive(true);
            pauseMenuEffects.gameObject.SetActive(true);
            pauseMenuBack.gameObject.SetActive(true);
            pauseMusicSlider.gameObject.SetActive(true);
            pauseEffectsSlider.gameObject.SetActive(true);

            isPaused = true;
        }
    }

    public void OnClickBackButton()
    {
        if (isPaused)
        {
            Time.timeScale = 1;

            isPaused = false;
            pauseMenuText.gameObject.SetActive(false);
            pauseMenuImage.gameObject.SetActive(false);
            pauseMenuPanel.gameObject.SetActive(false);
            pauseMenuBackground.gameObject.SetActive(false);
            pauseMenuMusic.gameObject.SetActive(false);
            pauseMenuEffects.gameObject.SetActive(false);
            pauseMenuBack.gameObject.SetActive(false);
            pauseMusicSlider.gameObject.SetActive(false);
            pauseEffectsSlider.gameObject.SetActive(false);

            PlayerPrefs.SetFloat("MusicVolumeSave", pauseMusicSlider.value);
            PlayerPrefs.SetFloat("EffectsVolumeSave", pauseEffectsSlider.value);
        }
    }
}
