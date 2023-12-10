using UnityEngine;

public class InputHandler: MonoBehaviour
{
    private static readonly int _actionsCount = System.Enum.GetNames(typeof(ActionType)).Length;
    private static float _firstDelay = 0.25f;
    private static float _secondDelay = 0.1f;

    private bool[] _lastPressedKeys = new bool[_actionsCount];
    private bool[] _pressedKeys = new bool[_actionsCount];
    private float[] _delays = new float[_actionsCount];

    public void Start()
    {
        EventBus.Subscribe<KeyPressed>(OnKeyPressed);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<KeyPressed>(OnKeyPressed);
    }

    private void OnKeyPressed(KeyPressed e)
    {
        _pressedKeys[(int)e.Key] = true;
    }

    private void Update()
    {
        for (int i = 0; i < _pressedKeys.Length; i++)
        {
            _delays[i] -= Time.deltaTime;

            if (_pressedKeys[i] == true && _lastPressedKeys[i] == false)
            {
                EventBus.Invoke(new ActionCalled((ActionType)i));
                _delays[i] = _firstDelay;
            }
            else
            {
                if (_pressedKeys[i] == true && _delays[i] <= 0)
                {
                    EventBus.Invoke(new ActionCalled((ActionType)i));
                    _delays[i] = _secondDelay;
                }
            }

            _lastPressedKeys[i] = _pressedKeys[i];
            _pressedKeys[i] = false;
        }
    }
}
