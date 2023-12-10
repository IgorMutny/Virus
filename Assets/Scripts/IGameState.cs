using UnityEngine;
using YG;

public interface IGameState
{
    public void Enter();
    public void Exit();
}

public class MainMenuState : IGameState
{
    private GameObject _mainMenu;

    public void Enter()
    {
        GameObject sample = ObjectDictionary.Get(typeof(MainMenu));
        _mainMenu = GameObject.Instantiate(sample);
    }

    public void Exit()
    {
        GameObject.Destroy(_mainMenu);
    }
}

public class LevelSelectionState : IGameState
{
    private GameObject _levelSelectionMenu;

    public void Enter()
    {
        GameObject sample = ObjectDictionary.Get(typeof(LevelSelectionMenu));
        _levelSelectionMenu = GameObject.Instantiate(sample);
        _levelSelectionMenu.GetComponent<LevelSelectionMenu>().Initialize();
    }

    public void Exit()
    {
        GameObject.Destroy(_levelSelectionMenu);
    }
}

public class GamePlayState : IGameState
{
    private int _levelNumber;
    private Level _level;

    public GamePlayState(int level)
    {
        _levelNumber = level;
    }

    public void Enter()
    {
        _level = new Level(_levelNumber);
    }

    public void Exit()
    {
        _level.Destroy();
        _level = null;
    }
}

public class AdState: IGameState
{
    public void Enter() 
    {
        YandexGame.FullscreenShow();
    }

    public void Exit() { }
}

public class CongratulationState : IGameState
{
    public void Enter()
    {
        Message congratulations =
            GameObject.Instantiate(ObjectDictionary.Get(typeof(Message))).GetComponent<Message>();
        congratulations.Initialize(7.2f, 3.5f, TextEnum.GameCompleted, true);
        congratulations.gameObject.AddComponent<CongratulationMessage>();
    }

    public void Exit() { }
}
