using UnityEngine;

public class ControlButton : Clickable
{
    [SerializeField] private ActionType _action;

    private void Start()
    {
        Initialize();
    }

    protected virtual void Execute()
    {
        EventBus.Invoke(new KeyPressed(_action));
    }

    protected override void Update()
    {
        base.Update();

        if (IsActivated == true)
        {
            Execute();
        }
    }
}
