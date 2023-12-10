using UnityEngine;

public interface ILevelState
{
    public void OnTimeStep();

    public void Exit();
}

public class HowToPlayState : ILevelState
{
    private HowToPlay _howToPlay;

    public HowToPlayState()
    {
        _howToPlay = new HowToPlay();
    }

    public void Exit()
    {
        _howToPlay = null;
    }

    public void OnTimeStep() { }
}

public class CountDownState : ILevelState
{
    private int _delayInSteps = 3;
    private CountDown _countDown;

    public CountDownState(int level)
    {
        _countDown = new CountDown(level, _delayInSteps);
    }

    public void Exit()
    {
        _countDown.Destroy();
        _countDown = null;
    }

    public void OnTimeStep()
    {
        _countDown.OnTimeStep();
    }
}

public class FigurePreparingState : ILevelState
{
    private FigureCreator _figureCreator;

    public FigurePreparingState(FigureCreator figureCreator)
    {
        _figureCreator = figureCreator;
    }

    public void Exit()
    {
        _figureCreator = null;
    }

    public void OnTimeStep()
    {
        _figureCreator.OnTimeStep();
    }
}

public class FigureInstallingState : ILevelState
{
    private FigureController _figureController;

    public FigureInstallingState(FigureController figureController, Figure figure)
    {
        _figureController = figureController;
        _figureController.SetFigure(figure);

        EventBus.Subscribe<ActionCalled>(OnActionCalled);
    }

    public void Exit()
    {
        EventBus.Unsubscribe<ActionCalled>(OnActionCalled);
        _figureController = null;
    }

    public void OnTimeStep()
    {
        _figureController.OnTimeStep();
    }

    public void OnActionCalled(ActionCalled e)
    {
        _figureController.TryExecute(e.Key);
    }
}

public class ContainerUpdatingState : ILevelState
{
    private Dropper _dropper;
    private Cleaner _cleaner;

    public ContainerUpdatingState(Dropper dropper, Cleaner cleaner)
    {
        _dropper = dropper;
        _cleaner = cleaner;
    }

    public void Exit()
    {
        _dropper = null;
        _cleaner = null;
    }

    public void OnTimeStep()
    {
        bool hasDestroyedCellsOnThisStep = _cleaner.Execute();
        bool hasDroppedCellsOnThisStep = false;

        if (hasDestroyedCellsOnThisStep == false)
        {
            hasDroppedCellsOnThisStep = _dropper.Execute();
        }

        if (hasDroppedCellsOnThisStep == false && hasDestroyedCellsOnThisStep == false)
        {
            EventBus.Invoke(new ContainerUpdated());
        }
    }
}

public class GameOverState : ILevelState
{
    private GameObject _menu;
    private GameOverType _type;
    private int _level;

    public GameOverState(GameOverType type, int level, Container container)
    {
        _type = type;
        _level = level;
        if (_type == GameOverType.Victory)
        {
            GameObject.Instantiate(ObjectDictionary.Get(typeof(SparkSpawner)), container.transform);
        }
        else if (_type == GameOverType.Defeat)
        {
            GameObject.Instantiate(ObjectDictionary.Get(typeof(Crack)), container.transform);
        }
        else if (_type == GameOverType.Restart)
        {
            EventBus.Invoke(new NextLevelDefined(_level));
            EventBus.Invoke(new GameStateChanged(new AdState()));
        }
        else if (_type == GameOverType.Abort)
        {
            EventBus.Invoke(new NextLevelDefined(CloseAd.MainMenuLevel));
            EventBus.Invoke(new GameStateChanged(new AdState()));
        }
    }

    public void OnTimeStep()
    {
        if (_menu == null)
        {
            if (_type == GameOverType.Victory)
            {
                if (_level != Level.MaxLevel)
                {
                    _menu = GameObject.Instantiate(ObjectDictionary.Get(typeof(WinMenu)));
                }
                else
                {
                    EventBus.Invoke(new GameStateChanged(new CongratulationState()));
                }
            }
            else if (_type == GameOverType.Defeat)
            {
                _menu = GameObject.Instantiate(ObjectDictionary.Get(typeof(LoseMenu)));
            }
        }
    }

    public void Exit()
    {
        if (_menu != null)
        {
            GameObject.Destroy(_menu.gameObject);
        }
    }
}