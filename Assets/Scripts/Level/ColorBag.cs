using System.Collections.Generic;
using UnityEngine;

public class ColorBag
{
    private List<ColorType> _colors;

    public ColorBag()
    {
        _colors = ColorDictionary.GetList();
    }

    public ColorType GetRandom()
    {
        ColorType result = _colors[Random.Range(0, _colors.Count)];
        _colors.Remove(result);

        if (_colors.Count == 0 )
        {
            _colors = ColorDictionary.GetList();
        }

        return result;
    }
}
