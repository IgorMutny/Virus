public class NewGameButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        EventBus.Invoke(new GameStateChanged(new LevelSelectionState()));
    }
}
