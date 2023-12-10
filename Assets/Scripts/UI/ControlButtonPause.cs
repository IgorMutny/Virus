public class ControlButtonPause : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        EventBus.Invoke(new GamePlayPaused(true));
    }
}
