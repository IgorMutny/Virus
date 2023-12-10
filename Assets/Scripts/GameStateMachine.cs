public class GameStateMachine
{
    private IGameState _currentState;

    public GameStateMachine()
    {
        EventBus.Subscribe<GameStateChanged>(OnGameStateChanged);

        _currentState = new MainMenuState();
        _currentState.Enter();
    }

    private void OnGameStateChanged(GameStateChanged e)
    {
        _currentState.Exit();
        _currentState = e.State;
        _currentState.Enter();
    }
}
