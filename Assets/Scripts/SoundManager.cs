using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip onClickSound;

    public void OnHoverButton()
    {
        audioSource.PlayOneShot(onClickSound);
    }
}
