using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Image backgroundImage;
    public Image backgroundImage2;
    public Image logoImage;
    public Image logoEnigma;
    public Image difficultyImage;
    public Button newGameButton;
    public Button optionsButton;
    public Button exitGameButton;
    public Button easyModeButton;
    public Button hardModeButton;
    public Button backButton;

    public void NewGameButton()
    {
        backgroundImage.gameObject.SetActive(false);
        backgroundImage2.gameObject.SetActive(true);
        logoImage.gameObject.SetActive(false);
        logoEnigma.gameObject.SetActive(false);
        difficultyImage.gameObject.SetActive(true);
        newGameButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitGameButton.gameObject.SetActive(false);
        easyModeButton.gameObject.SetActive(true);
        hardModeButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void EasyModeButton()
    {
        SceneManager.LoadScene("");
    }

    public void HardModeButton()
    {
        SceneManager.LoadScene("");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MenuBackButton()
    {
        backgroundImage.gameObject.SetActive(true);
        backgroundImage2.gameObject.SetActive(false);
        logoImage.gameObject.SetActive(true);
        logoEnigma.gameObject.SetActive(true);
        difficultyImage.gameObject.SetActive(false);
        newGameButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        exitGameButton.gameObject.SetActive(true);
        easyModeButton.gameObject.SetActive(false);
        hardModeButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
