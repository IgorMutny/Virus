using UnityEngine;

public class HowToPlayMessage : MonoBehaviour
{
    private HowToPlay _howToPlay;

    public void SetParent(HowToPlay howToPlay)
    {
        _howToPlay = howToPlay;
    }

    public void Close()
    {
        _howToPlay.TryShowNextMessage();
        Destroy(gameObject);
    }
}
