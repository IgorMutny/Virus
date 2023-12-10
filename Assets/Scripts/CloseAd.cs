using UnityEngine;

public class CloseAd : MonoBehaviour
{
    public static readonly int MainMenuLevel = -1;

    private int _nextLevel = MainMenuLevel;

    private void Start()
    {
        EventBus.Subscribe<NextLevelDefined>(OnNextLevelDefined);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<NextLevelDefined>(OnNextLevelDefined);
    }

    private void OnNextLevelDefined(NextLevelDefined e)
    {
        _nextLevel = e.Value;
    }

    public void OnCloseAd()
    {
        if (_nextLevel == MainMenuLevel)
        {
            EventBus.Invoke(new GameStateChanged(new MainMenuState()));
        }
        else
        {
            EventBus.Invoke(new GameStateChanged(new GamePlayState(_nextLevel)));
        }
    }
}
