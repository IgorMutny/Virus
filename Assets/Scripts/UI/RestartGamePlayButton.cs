public class RestartGamePlayButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        EventBus.Invoke(new GameOver(GameOverType.Restart));
    }
}
