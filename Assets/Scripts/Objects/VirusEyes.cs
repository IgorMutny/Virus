using UnityEngine;

public class VirusEyes : MonoBehaviour
{
    [SerializeField] private Sprite _open;
    [SerializeField] private Sprite _closed;

    private SpriteRenderer _spriteRenderer;
    private float _maxStarringTime = 4f;
    private float _minStarringTime = 0.5f;
    private float _blinkingTime = 0.1f;
    private bool _isBlinking = false;
    private float _animationTime;

    public void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animationTime = Random.Range(_minStarringTime, _maxStarringTime);
    }

    public void FixedUpdateExtended()
    {
        _animationTime -= Time.fixedDeltaTime;

        if (_animationTime <= 0 && _isBlinking == false)
        {
            _isBlinking = true;
            _animationTime = _blinkingTime;
            _spriteRenderer.sprite = _closed;
        }

        if (_animationTime <= 0 && _isBlinking == true)
        {
            _isBlinking = false;
            _animationTime = Random.Range(_minStarringTime, _maxStarringTime);
            _spriteRenderer.sprite = _open;
        }
    }
}
