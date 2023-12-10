public class StartGameImmediatelyButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        int level = PlayerStats.Instance.LastSelectedLevel;
        EventBus.Invoke(new GameStateChanged(new GamePlayState(level)));
    }
}
