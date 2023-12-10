using UnityEngine;

public abstract class Slider : Clickable
{
    [SerializeField] private Transform _sliderButton;
    [SerializeField] private float _size;

    protected float _value;

    public override void Initialize()
    {
        base.Initialize();

        _sliderButton.GetComponent<SpriteRenderer>().color = StandartColor;

        SetInitialValue();
        ApplyValue();
        UpdateSliderButtonPosition();
    }

    protected override void Update()
    {
        base.Update();

        if (IsActivated == true)
        {
            GetNewValue();
            ApplyValue();
            UpdateSliderButtonPosition();
        }

        if (IsJustDeactivated == true)
        { 
            OnDeactivate();
        }
    }

    private void GetNewValue()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        _value = (x - transform.position.x) / _size + 0.5f;
        _value = Mathf.Clamp01(_value);
    }

    private void UpdateSliderButtonPosition()
    {
        float x = (_value - 0.5f) * _size + transform.position.x;
        _sliderButton.position = new Vector2(x, transform.position.y);
    }

    protected virtual void ApplyValue() { }

    protected virtual void OnDeactivate() { }

    protected virtual void SetInitialValue()
    {
        _value = 1;
    }
}
