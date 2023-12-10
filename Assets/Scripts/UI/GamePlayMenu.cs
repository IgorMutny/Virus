using UnityEngine;

public class GamePlayMenu : Menu
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Clickable.StandartColor;
    }
}
