using UnityEngine;
using YG;

public class EntryPoint : MonoBehaviour
{
    private bool SDKEnabled = false;

    private void Update()
    {
        if (YandexGame.SDKEnabled == true && SDKEnabled == false)
        {
            SDKEnabled = true;
            StartExtended();
        }
    }

    private void StartExtended()
    {
        new PlayerStats();
        new GameStateMachine();
    }
}
