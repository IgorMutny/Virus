using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            EventBus.Invoke(new KeyPressed(ActionType.MoveLeft));
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            EventBus.Invoke(new KeyPressed(ActionType.MoveRight));
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            EventBus.Invoke(new KeyPressed(ActionType.Drop));
        }

        if (Input.GetKey(KeyCode.X) == true)
        {
            EventBus.Invoke(new KeyPressed(ActionType.TurnRight));
        }

        if (Input.GetKey(KeyCode.Z) == true)
        {
            EventBus.Invoke(new KeyPressed(ActionType.TurnLeft));
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            EventBus.Invoke(new GamePlayPaused(true));
        }
    }
}

