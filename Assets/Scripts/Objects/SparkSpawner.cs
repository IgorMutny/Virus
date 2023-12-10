using UnityEngine;

public class SparkSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _sparkSample;

    private Vector2 _minPosition = new Vector2(-4.5f, 0);
    private Vector2 _maxPosition = new Vector2(4.5f, 8.5f);

    private float _minSparkTime = 0.25f;
    private float _maxSparkTime = 0.75f;

    private float _currentSparkTime;

    private void Start()
    {
        EventBus.Invoke(new ContainerCleaned());
        SetCurrentSparkTime();
    }

    private void FixedUpdate()
    {
        _currentSparkTime -= Time.fixedDeltaTime;

        if (_currentSparkTime <= 0 )
        {
            SetCurrentSparkTime();
            CreateSpark();
        }
    }

    private void SetCurrentSparkTime()
    {
        _currentSparkTime = Random.Range(_minSparkTime, _maxSparkTime);
    }

    private void CreateSpark()
    {
        float x = transform.position.x + Random.Range(_minPosition.x, _maxPosition.x);
        float y = transform.position.y + Random.Range(_minPosition.y, _maxPosition.y);
        Vector2 position = new Vector2(x, y);
        float angle = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(angle, 0, 0);

        Instantiate(_sparkSample, position, rotation, transform);
    }
}
