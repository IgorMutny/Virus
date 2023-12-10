using UnityEngine;

public class LevelSelectionButton : Button
{
    private bool _isActive;
    private bool _isSelected;
    public int Level { get; private set; }

    public void Initialize(int level)
    {
        base.Initialize();

        Level = level;
        Description.SetText((Level + 1).ToString());
    }

    public void SetState(bool isActive, bool isSelected)
    {
        _isActive = isActive;
        _isSelected = isSelected;

        if (_isActive == true)
        {
            if (_isSelected == true)
            {
                SpriteRenderer.color = ActiveColor;
            }
            else
            {
                SpriteRenderer.color = StandartColor;
            }
        }
        else
        {
            SpriteRenderer.color = UnavailableColor;
        }
    }

    protected override void Execute()
    {
        if (_isActive == true)
        {
            LevelSelectionMenu levelSelectionMenu = GetComponentInParent<LevelSelectionMenu>();
            levelSelectionMenu.SetLevel(Level);
        }
    }
}
