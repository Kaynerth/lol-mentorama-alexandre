using UnityEngine;
using UnityEngine.UI;

public class FullScreenChange : MonoBehaviour
{
    [HideInInspector] public FullScreenMode fullScreenMode;
    [HideInInspector] public bool isFullScreen;

    private void Awake()
    {
        FullscreenToogle();
    }

    public void FullscreenToogle()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            fullScreenMode = FullScreenMode.FullScreenWindow;
            isFullScreen = true;
        }
        else
        {
            fullScreenMode = FullScreenMode.Windowed;
            isFullScreen = false;
        }

        Screen.fullScreenMode = fullScreenMode;
    }
}
