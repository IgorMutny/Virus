using UnityEngine;

public class CongratulationMessage : MonoBehaviour
{
    public void Close()
    {
        EventBus.Invoke(new GameStateChanged(new MainMenuState()));
        Destroy(gameObject);
    }
}
