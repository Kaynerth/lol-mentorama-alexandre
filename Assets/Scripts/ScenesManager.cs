using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void NewGameButton()
    {

    }

    public void EasyModeButton()
    {

    }

    public void HardModeButton()
    {

    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
