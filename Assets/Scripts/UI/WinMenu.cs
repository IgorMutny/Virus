using UnityEngine;

public class WinMenu : Menu
{
    [SerializeField] private TextBox _textBox;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Clickable.StandartColor;
        _textBox.Initialize(TextEnum.WinText);
    }
}
