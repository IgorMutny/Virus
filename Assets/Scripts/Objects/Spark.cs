using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

    private float _animationTime = 0.02f;
    private float _currentAnimationTime;
    private int _spriteIndex;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteIndex = 0;
        _currentAnimationTime = _animationTime;
        _spriteRenderer.sprite = _sprites[_spriteIndex];
    }

    private void FixedUpdate()
    {
        _currentAnimationTime -= Time.fixedDeltaTime;

        if (_currentAnimationTime <= 0 )
        { 
            if (_spriteIndex < _sprites.Count - 1)
            {
                _spriteIndex += 1;
                _currentAnimationTime = _animationTime;
                _spriteRenderer.sprite = _sprites[_spriteIndex];
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
