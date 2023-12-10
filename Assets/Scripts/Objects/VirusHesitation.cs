using UnityEngine;

public class VirusHesitation : MonoBehaviour
{
    private float _hesitationSpeed = 1f;
    private float _hesitationDistance = 0.1f;

    private Vector2 _startPosition;
    private Vector2 _targetPosition;

    public void Initialize()
    {
        _startPosition = transform.position;
        _targetPosition = transform.position;
    }

    public void FixedUpdateExtended()
    {
        Vector2 currentPosition = (Vector2)transform.position;

        if ((currentPosition - _targetPosition).magnitude > _hesitationSpeed * Time.fixedDeltaTime)
        {
            Vector2 direction = _targetPosition - currentPosition;
            currentPosition += direction * _hesitationSpeed * Time.fixedDeltaTime;
            transform.position = currentPosition;
        }

        if ((currentPosition - _targetPosition).magnitude <= _hesitationSpeed * Time.fixedDeltaTime)
        {
            float offsetX = Random.Range(-1f, 1f);
            float offsetY = Random.Range(-1f, 1f);
            Vector2 offset = new Vector2(offsetX, offsetY).normalized * _hesitationDistance;
            _targetPosition = _startPosition + offset;
        }
    }
}
