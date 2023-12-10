using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _stepTime;
    private float _currentStepTime;

    private bool _isPaused = false;

    public void SetStep(float stepTime)
    {
        _stepTime = stepTime;
        _currentStepTime = stepTime;
    }

    public void Erase()
    {
        Destroy(gameObject);
    }

    public void Pause(bool isPaused)
    {
        _isPaused = isPaused;
    }

    private void FixedUpdate()
    {
        if (_isPaused == false)
        {
            _currentStepTime -= Time.fixedDeltaTime;

            if (_currentStepTime <= 0)
            {
                EventBus.Invoke(new TimeStep());
                _currentStepTime = _stepTime;
            }
        }
    }
}
