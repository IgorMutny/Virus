using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _figureInstalled;
    [SerializeField] private AudioClip _cellCleaned;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _tick;
    [SerializeField] private AudioClip _button;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        EventBus.Subscribe<SoundVolumeChanged>(OnSoundVolumeChanged);

        EventBus.Subscribe<FigureInstalled>(OnFigureInstalled);
        EventBus.Subscribe<CellCleaned>(OnCellCleaned);
        EventBus.Subscribe<CountDownTick>(OnCountDownTick);
        EventBus.Subscribe<ButtonPressed>(OnButtonPressed);
        EventBus.Subscribe<ContainerCracked>(OnContainerCracked);
        EventBus.Subscribe<ContainerCleaned>(OnContainerCleaned);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<SoundVolumeChanged>(OnSoundVolumeChanged);

        EventBus.Unsubscribe<FigureInstalled>(OnFigureInstalled);
        EventBus.Unsubscribe<CellCleaned>(OnCellCleaned);
        EventBus.Unsubscribe<CountDownTick>(OnCountDownTick);
        EventBus.Unsubscribe<ButtonPressed>(OnButtonPressed);
        EventBus.Unsubscribe<ContainerCracked>(OnContainerCracked);
        EventBus.Unsubscribe<ContainerCleaned>(OnContainerCleaned);
    }

    private void OnSoundVolumeChanged(SoundVolumeChanged e)
    {
        _audioSource.volume = e.Volume;
    }

    private void OnFigureInstalled(FigureInstalled e)
    {
        Play(_figureInstalled);
    }

    private void OnCellCleaned (CellCleaned e)
    {
        Play(_cellCleaned);
    }

    private void OnContainerCracked(ContainerCracked e)
    {
        Play(_lose);
    }

    private void OnContainerCleaned(ContainerCleaned e)
    {
        Play(_win);
    }

    private void OnCountDownTick(CountDownTick e)
    {
        Play(_tick);
    }

    private void OnButtonPressed(ButtonPressed e)
    {
        Play(_button);
    }

    private void Play(AudioClip _clip)
    {
        _audioSource.clip = _clip;
        _audioSource.Play();
    }
}
