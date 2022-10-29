using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
}
