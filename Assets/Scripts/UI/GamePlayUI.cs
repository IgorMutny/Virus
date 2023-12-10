using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private TextBox _nextFigureText;
    [SerializeField] private TextBox _virusesCountText;
    [SerializeField] private TextBox _virusesCount;
    [SerializeField] private GameObject _controlButtons;

    public void Initialize()
    {
        _nextFigureText.Initialize(TextEnum.Next, 5);
        _virusesCountText.Initialize(TextEnum.Viruses, 5);
        _virusesCount.Initialize(5);

        EventBus.Subscribe<VirusesCountChanged>(OnVirusesCountChanged);
    }

    public void SwitchControls(bool isActive)
    {
        _controlButtons.SetActive(isActive);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<VirusesCountChanged>(OnVirusesCountChanged);
    }

    private void OnVirusesCountChanged(VirusesCountChanged e)
    {
        _virusesCount.SetText($"{e.VirusesRemained} / {e.VirusesTotal}");
    }
}
