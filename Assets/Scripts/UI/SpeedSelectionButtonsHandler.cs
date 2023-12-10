using System.Collections.Generic;
using UnityEngine;

public class SpeedSelectionButtonsHandler
{
    private LevelSelectionMenu _menu;
    private List<SpeedSelectionButton> _buttons = new();

    private GameObject _buttonSample;
    private Vector2 _buttonsStartPosition = new Vector2(1, 14);
    private float _buttonsHorizontalDistance = 4.5f;

    public SpeedSelectionButtonsHandler(LevelSelectionMenu menu)
    {
        _menu = menu;
        _buttonSample = ObjectDictionary.Get(typeof(SpeedSelectionButton));
        CreateButtons();
    }

    public void SetButtonsStates(int speed)
    {
        foreach (SpeedSelectionButton button in _buttons)
        {
            bool isSelected = _buttons.IndexOf(button) == speed;
            button.SetState(isSelected);
        }
    }

    private void CreateButtons()
    {
        for (int speed = 0; speed <= Level.MaxSpeed; speed++)
        {
            float x = _buttonsStartPosition.x + speed * _buttonsHorizontalDistance;
            float y = _buttonsStartPosition.y;
            SpeedSelectionButton button = CreateButton(speed, x, y);
            _buttons.Add(button);
        }
    }

    private SpeedSelectionButton CreateButton(int speed, float x, float y)
    {
        SpeedSelectionButton button = 
            GameObject.Instantiate(_buttonSample, new Vector2(x, y), Quaternion.identity, _menu.transform)
            .GetComponent<SpeedSelectionButton>();
        button.Initialize(speed);
        return button;
    }
}
