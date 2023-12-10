using UnityEngine;

public class Pill : Cell
{
    private Pill _pair;

    public Pill Pair
    {
        get
        {
            return _pair;
        }
        set
        {
            _pair = value;
            UpdateDirection();
        }
    }

    public void UpdateDirection()
    {
        Vector2Int direction;
        if (Pair != null)
        {
            direction = Vector2Int.RoundToInt(transform.position - _pair.transform.position);
        }
        else
        {
            direction = Vector2Int.zero;
        }

        Sprite sprite = PillSpriteDictionary.Get(direction);
        _spriteRenderer.sprite = sprite;
    }

    private void OnDestroy()
    {
        if (_pair != null)
        {
            _pair.Pair = null;
        }
    }
}
