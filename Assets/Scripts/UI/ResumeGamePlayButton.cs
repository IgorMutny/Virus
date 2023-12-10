public class ResumeGamePlayButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        EventBus.Invoke(new GamePlayPaused(false));
    }
}
