using UnityEngine;

public class LanguageSwitcher : Switcher
{
    [SerializeField] private TextBox _engText;
    [SerializeField] private TextBox _rusText;

    private void Start()
    {
        Initialize();

        _engText.Initialize();
        _engText.SetText("ENG");
        _rusText.Initialize();
        _rusText.SetText("ÐÓÑ");
    }

    protected override void SetInitialValue()
    {
        _value = PlayerStats.Instance.Language == Language.English;
    }

    protected override void ApplyInitialValue()
    {
        if (_value == true)
        {
            PlayerStats.Instance.SetLanguage(Language.English);
        }
        else
        {
            PlayerStats.Instance.SetLanguage(Language.Russian);
        }
    }

    protected override void ApplyValue()
    {
        ApplyInitialValue();
        EventBus.Invoke(new GameStateChanged(new MainMenuState()));
    }
}
