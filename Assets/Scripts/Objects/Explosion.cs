using System.Collections.Generic;
using UnityEngine;

public class Explosion: MonoBehaviour
{
    [SerializeField] private int _smokeCount;

    private float _lifeTime;
    private List<Smoke> _smokes = new();

    public void Initialize(ColorType color, float lifeTime)
    {
        _lifeTime = lifeTime;

        CreateSmoke(color);
    }

    private void CreateSmoke(ColorType color)
    {
        for (int i = 0; i < _smokeCount; i++)
        {
            GameObject sample = ObjectDictionary.Get(typeof(Smoke));
            Smoke smoke = Instantiate(sample, transform.position, Quaternion.identity, transform)
                .GetComponent<Smoke>();
            smoke.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
            smoke.Initialize(ColorDictionary.Get(color), _lifeTime);
            _smokes.Add(smoke);
        }
    }

    private void FixedUpdate()
    {
        foreach (Smoke smoke in _smokes)
        {
            if (smoke != null)
            {
                smoke.FixedUpdateExtended();
            }
        }
        
        _lifeTime -= Time.fixedDeltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
