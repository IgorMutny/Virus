using UnityEngine;

public abstract class Switcher : Clickable
{
    [SerializeField] private Transform _switcherButton;
    [SerializeField] private float _size;

    protected bool _value = true;

    public override void Initialize()
    {
        base.Initialize();

        _switcherButton.GetComponent<SpriteRenderer>().color = StandartColor;

        SetInitialValue();
        ApplyInitialValue();
        UpdateSwitcherButtonPosition();
    }

    protected override void Update()
    {
        base.Update();

        if (IsActivatedOnce == true)
        {
            GetNewValue();
            ApplyValue();
            UpdateSwitcherButtonPosition();
        }
    }

    private void UpdateSwitcherButtonPosition()
    {
        if (_value == true)
        {
            _switcherButton.position = transform.position + new Vector3(_size, 0, 0);
        }
        else
        {
            _switcherButton.position = transform.position - new Vector3(_size, 0, 0);
        }
    }

    private void GetNewValue()
    {
        _value = !_value;
    }

    protected abstract void ApplyValue();

    protected abstract void ApplyInitialValue();

    protected virtual void SetInitialValue()
    {
        _value = true;
    }
}
