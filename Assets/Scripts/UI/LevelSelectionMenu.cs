using UnityEngine;

public class LevelSelectionMenu : Menu
{
    [SerializeField] private TextBox _levelText;
    [SerializeField] private TextBox _speedText;

    private LevelSelectionButtonsHandler _levelSelectionButtonsHandler;
    private SpeedSelectionButtonsHandler _speedSelectionButtonsHandler;
    private int _selectedSpeed;
    private int _selectedLevel;
    private int _maxAllowedLevel;

    public void Initialize()
    {
        _speedText.Initialize(TextEnum.Speed);
        _levelText.Initialize(TextEnum.Level);

        GetPlayerStats();

        _speedSelectionButtonsHandler = new SpeedSelectionButtonsHandler(this);
        _speedSelectionButtonsHandler.SetButtonsStates(_selectedSpeed);

        _levelSelectionButtonsHandler = new LevelSelectionButtonsHandler(this);
        _levelSelectionButtonsHandler.SetButtonsStates(_selectedSpeed, _maxAllowedLevel, _selectedLevel);
    }

    public void SetSpeed(int speed)
    {
        _selectedSpeed = speed;
        _speedSelectionButtonsHandler.SetButtonsStates(_selectedSpeed);
        _levelSelectionButtonsHandler.SetButtonsStates(_selectedSpeed, _maxAllowedLevel, _selectedLevel);
    }

    public void SetLevel(int level)
    {
        _selectedLevel = level;
        _levelSelectionButtonsHandler.SetButtonsStates(_selectedSpeed, _maxAllowedLevel, _selectedLevel);
        PlayerStats.Instance.TrySetLastSelectedLevel(_selectedLevel);
    }

    public void StartLevel()
    {
        EventBus.Invoke(new GameStateChanged(new GamePlayState(_selectedLevel)));
    }

    private void GetPlayerStats()
    {
        _maxAllowedLevel = PlayerStats.Instance.MaxAllowedLevel;
        _selectedLevel = PlayerStats.Instance.LastSelectedLevel;

        _selectedSpeed = LevelCalculator.Speed(_selectedLevel);
    }
}
