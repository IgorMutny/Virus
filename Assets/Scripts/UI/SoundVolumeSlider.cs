public class SoundVolumeSlider : Slider
{
    private void Start()
    {
        Initialize();
    }

    protected override void ApplyValue()
    {
        EventBus.Invoke(new SoundVolumeChanged(_value));
    }

    protected override void OnDeactivate()
    {
        PlayerStats.Instance.SetSoundVolume(_value);
    }

    protected override void SetInitialValue()
    {
        _value = PlayerStats.Instance.SoundVolume;
    }
}
