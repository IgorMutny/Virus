public class MainMenuButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        EventBus.Invoke(new GameStateChanged(new MainMenuState()));
    }
}
