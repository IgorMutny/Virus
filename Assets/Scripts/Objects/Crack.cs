using UnityEngine;

public class Crack : MonoBehaviour
{
    private void Start()
    {
        EventBus.Invoke(new ContainerCracked());
    }
}
