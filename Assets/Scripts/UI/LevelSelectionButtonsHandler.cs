using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionButtonsHandler
{
    private LevelSelectionMenu _menu;
    private List<List<LevelSelectionButton>> _buttons = new();

    private GameObject _buttonSample;
    private Vector2 _buttonsStartPosition = new Vector2(0.5f, 10);
    private float _buttonsHorizontalDistance = 2.5f;
    private float _buttonsVerticalDistance = 2.5f;
    private int _buttonsInRow = 5;

    public LevelSelectionButtonsHandler(LevelSelectionMenu menu)
    {
        _menu = menu;
        _buttonSample = ObjectDictionary.Get(typeof(LevelSelectionButton));
        CreateButtons();
    }

    public void SetButtonsStates(int speed, int maxAllowedLevel, int lastSelectedLevel)
    {
        foreach (List<LevelSelectionButton> buttons in _buttons)
        {
            bool isActive = _buttons.IndexOf(buttons) == speed;

            foreach (LevelSelectionButton button in buttons)
            {
                button.gameObject.SetActive(isActive);
                bool isActiveButton = button.Level <= maxAllowedLevel;
                bool isSelectedButton = button.Level == lastSelectedLevel;
                button.SetState(isActiveButton, isSelectedButton);
            }
        }
    }

    private void CreateButtons()
    {
        int level = 0;

        for (int speed = 0; speed <= Level.MaxSpeed; speed++)
        {
            List<LevelSelectionButton> buttons = new();
            _buttons.Add(buttons);

            for (int i = 0; i <= Level.MaxLevelInOneSpeed; i++)
            {
                int xCount = i % _buttonsInRow;
                int yCount = i / _buttonsInRow;
                float x = _buttonsStartPosition.x + xCount * _buttonsHorizontalDistance;
                float y = _buttonsStartPosition.y - yCount * _buttonsVerticalDistance;

                LevelSelectionButton button = CreateButton(level, x, y);
                buttons.Add(button);

                level += 1;
            }
        }
    }

    private LevelSelectionButton CreateButton(int level, float x, float y)
    {
        LevelSelectionButton button = 
            GameObject.Instantiate(_buttonSample, new Vector2(x, y), Quaternion.identity, _menu.transform)
            .GetComponent<LevelSelectionButton>();
        button.Initialize(level);
        return button;
    }
}
