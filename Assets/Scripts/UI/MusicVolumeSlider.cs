public class MusicVolumeSlider : Slider
{
    private void Start()
    {
        Initialize();
    }

    protected override void ApplyValue()
    {
        EventBus.Invoke(new MusicVolumeChanged(_value));
    }

    protected override void OnDeactivate()
    {
        PlayerStats.Instance.SetMusicVolume(_value);
    }

    protected override void SetInitialValue()
    {
        _value = PlayerStats.Instance.MusicVolume;
    }
}
