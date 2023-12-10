public class StartLevelButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        GetComponentInParent<LevelSelectionMenu>().StartLevel();
    }
}
