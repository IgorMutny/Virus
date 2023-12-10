using System.Collections.Generic;
using UnityEngine;

public class VirusLeg : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

    private SpriteRenderer _spriteRenderer;

    private float _maxAnimationTime = 0.1f;
    private float _minAnimationTime = 0.05f;
    private float _currentAnimationTime;
    private int _currentSprite;

    public void Initialize(Color color)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = color;
        _currentSprite = Random.Range(0, _sprites.Count);
        UpdateAnimation();
    }

    public void FixedUpdateExtended()
    {
        _currentAnimationTime -= Time.fixedDeltaTime;
        if (_currentAnimationTime <= 0)
        {
            UpdateAnimation();
        }
    }

    private void UpdateAnimation()
    {
        _currentAnimationTime = Random.Range(_minAnimationTime, _maxAnimationTime);

        _currentSprite += 1;
        if (_currentSprite >= _sprites.Count)
        {
            _currentSprite = 0;
        }

        _spriteRenderer.sprite = _sprites[_currentSprite];
    }
}
