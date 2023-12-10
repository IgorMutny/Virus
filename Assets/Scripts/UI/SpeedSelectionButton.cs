using UnityEngine;

public class SpeedSelectionButton : Button
{
    private int _speed;
    private bool _isSelected;

    public void Initialize(int speed)
    {
        base.Initialize();

        _speed = speed;

        TextEnum speedName;
        switch (_speed)
        {
            case 0: speedName = TextEnum.NormalSpeed; break;
            case 1: speedName = TextEnum.FastSpeed; break;
            case 2: speedName = TextEnum.CrazySpeed; break;
            default: speedName = TextEnum.NormalSpeed; break;
        }

        Description.SetText(TextDictionary.Get(speedName));
    }

    public void SetState(bool isSelected)
    {
        _isSelected = isSelected;

        if (_isSelected == true)
        {
            SpriteRenderer.color = ActiveColor;
        }
        else
        {
            SpriteRenderer.color = StandartColor;
        }
    }

    protected override void Execute()
    {
        LevelSelectionMenu levelSelectionMenu = GetComponentInParent<LevelSelectionMenu>();
        levelSelectionMenu.SetSpeed(_speed);
    }
}
