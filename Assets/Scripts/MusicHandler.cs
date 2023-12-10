using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        EventBus.Subscribe<MusicVolumeChanged>(OnMusicVolumeChanged);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<MusicVolumeChanged>(OnMusicVolumeChanged);
    }

    private void OnMusicVolumeChanged(MusicVolumeChanged e)
    {
        _audioSource.volume = e.Volume;
    }
}
