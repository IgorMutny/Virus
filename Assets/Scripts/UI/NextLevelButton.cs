public class NextLevelButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        int level = PlayerStats.Instance.LastSelectedLevel;
        EventBus.Invoke(new NextLevelDefined(level));
        EventBus.Invoke(new GameStateChanged(new AdState()));
    }

}
