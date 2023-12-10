using System.Collections.Generic;
using UnityEngine;

public class PositionBag
{
    private List<Vector2Int> _positions = new();

    public PositionBag(ColorTable colorTable, int infectedHeight, ColorType color)
    {
        for (int x = 0; x < Container.Width; x++)
        {
            for (int y = 0; y < infectedHeight; y++)
            {
                if (colorTable.Get(x, y) == color)
                {
                    _positions.Add(new Vector2Int(x, y));
                }
                
            }
        }
    }

    public bool IsEmpty()
    {
        return _positions.Count == 0;
    }

    public Vector2Int GetRandom()
    {
        Vector2Int result = _positions[Random.Range(0, _positions.Count)];
        _positions.Remove(result);
        return result;
    }
}
