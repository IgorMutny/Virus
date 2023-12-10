using UnityEngine;

public class Level
{
    public static readonly int MaxSpeed = 2;
    public static readonly int MaxLevelInOneSpeed = 19;
    public static readonly int MaxLevel = 59;

    private int _level;
    private Timer _timer;
    private Container _container;
    private FigureCreator _figureCreator;
    private FigureController _figureController;
    private Dropper _dropper;
    private Cleaner _cleaner;
    private GameObject _gamePlayMenu;
    private GamePlayUI _gamePlayUI;
    private ILevelState _currentState;

    private float _timeStep;
    private float _maxTimeStep = 1f;
    private float _minTimeStep;

    public Level(int level)
    {
        _level = level;

        _timeStep = LevelCalculator.TimeStep(_level);
        _minTimeStep = LevelCalculator.TimeStep(MaxLevel);

        _timer = GameObject.Instantiate(ObjectDictionary.Get(typeof(Timer))).GetComponent<Timer>();
        _timer.SetStep(_maxTimeStep);
        _gamePlayMenu = GameObject.Instantiate(ObjectDictionary.Get(typeof(GamePlayMenu)));
        _gamePlayMenu.SetActive(false);

        _gamePlayUI = GameObject.Instantiate(ObjectDictionary.Get(typeof(GamePlayUI))).GetComponent<GamePlayUI>();
        _gamePlayUI.Initialize();

        _container = GameObject.Instantiate(ObjectDictionary.Get(typeof(Container))).GetComponent<Container>();
        _container.Initialize(_level);

        _figureCreator = new FigureCreator(_container);
        _figureController = new FigureController(_container);
        _dropper = new Dropper(_container);
        _cleaner = new Cleaner(_container);

        Subscribe();

        if (_level != 0)
        {
            SetNewState(new CountDownState(_level));
        }
        else
        {
            SetNewState(new HowToPlayState());
        }

        _figureCreator.Create();
    }

    public void Destroy()
    {
        Erase();
        Unsubscribe();
    }

    private void OnHowToPlayFinished(HowToPlayFinished e)
    {
        SetNewState(new CountDownState(_level));
    }

    private void OnTimeStep(TimeStep e)
    {
        _currentState.OnTimeStep();
    }

    private void OnFigurePrepared(FigurePrepared e)
    {
        _timer.SetStep(_timeStep);
        _figureCreator.Reload();
        SetNewState(new FigureInstallingState(_figureController, e.Figure));
    }

    private void OnFigureInstalled(FigureInstalled e)
    {
        _timer.SetStep(_minTimeStep);
        SetNewState(new ContainerUpdatingState(_dropper, _cleaner));
    }

    private void OnContainerUpdated(ContainerUpdated e)
    {
        _timer.SetStep(_timeStep);
        SetNewState(new FigurePreparingState(_figureCreator));
    }

    private void OnGameOver(GameOver e)
    {
        if (e.Type == GameOverType.Victory)
        {
            int newLevel = _level + 1;
            if (newLevel <= MaxLevel)
            {
                PlayerStats.Instance.TrySetMaxAllowedLevel(newLevel);
                PlayerStats.Instance.TrySetLastSelectedLevel(newLevel);
            }
        }

        _timer.SetStep(_maxTimeStep);

        SetNewState(new GameOverState(e.Type, _level, _container));
    }

    private void OnGamePlayPaused(GamePlayPaused e)
    {
        bool canBePaused = _currentState is not HowToPlayState && _currentState is not GameOverState;

        if (canBePaused == true)
        {
            _timer.Pause(e.Value);
            _gamePlayMenu.SetActive(e.Value);

            bool controlsAreHidden = !e.Value;
            _gamePlayUI.SwitchControls(controlsAreHidden);
        }
    }

    private void Erase()
    {
        _currentState.Exit();
        _currentState = null;

        GameObject.Destroy(_gamePlayMenu);
        GameObject.Destroy(_gamePlayUI.gameObject);

        _container.Erase();
        _container = null;
        _timer.Erase();
        _timer = null;
        _figureCreator.Erase();
        _figureCreator = null;
        _figureController.Erase();
        _figureController = null;
        _dropper = null;
        _cleaner = null;
    }

    private void SetNewState(ILevelState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
    }

    private void Subscribe()
    {
        EventBus.Subscribe<TimeStep>(OnTimeStep);
        EventBus.Subscribe<FigurePrepared>(OnFigurePrepared);
        EventBus.Subscribe<FigureInstalled>(OnFigureInstalled);
        EventBus.Subscribe<ContainerUpdated>(OnContainerUpdated);
        EventBus.Subscribe<GamePlayPaused>(OnGamePlayPaused);
        EventBus.Subscribe<GameOver>(OnGameOver);

        if (_level == 0)
        {
            EventBus.Subscribe<HowToPlayFinished>(OnHowToPlayFinished);
        }
    }

    private void Unsubscribe()
    {
        EventBus.Unsubscribe<TimeStep>(OnTimeStep);
        EventBus.Unsubscribe<FigurePrepared>(OnFigurePrepared);
        EventBus.Unsubscribe<FigureInstalled>(OnFigureInstalled);
        EventBus.Unsubscribe<ContainerUpdated>(OnContainerUpdated);
        EventBus.Unsubscribe<GamePlayPaused>(OnGamePlayPaused);
        EventBus.Unsubscribe<GameOver>(OnGameOver);

        if (_level == 0)
        {
            EventBus.Unsubscribe<HowToPlayFinished>(OnHowToPlayFinished);
        }
    }
}
