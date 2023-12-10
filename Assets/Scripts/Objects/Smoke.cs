using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class Smoke : MonoBehaviour
{
    [SerializeField] private float _distance;

    private SpriteRenderer _spriteRenderer;
    private float _lifeTime;
    private float _currentLifeTime;
    private float _speed;

    public void Initialize(Color color, float lifetime)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = color;

        _lifeTime = lifetime;
        _currentLifeTime = _lifeTime;
        _speed = _distance / _lifeTime;
    }

    public void FixedUpdateExtended()
    {
        _currentLifeTime -= Time.fixedDeltaTime;

        float alpha = _currentLifeTime / _lifeTime;
        Color color = _spriteRenderer.color;
        _spriteRenderer.color = new Color(color.r, color.g, color.b, alpha);

        transform.Translate(Vector3.up * _speed * Time.fixedDeltaTime);

        if (_currentLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
