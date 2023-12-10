using System.Collections.Generic;
using UnityEngine;

public static class ColorDictionary
{
    private static Dictionary<ColorType, Color> _dictionary = new();

    static ColorDictionary()
    {
        _dictionary.Add(ColorType.Red, new Color(0.92f, 0.08f, 0.08f)); // new Color(0.9f, 0.1f, 0.1f));
        _dictionary.Add(ColorType.Green, new Color(0.92f, 0.92f, 0.08f)); // new Color(0.9f, 0.9f, 0.1f));
        _dictionary.Add(ColorType.Blue, new Color(0.08f, 0.3f, 0.92f)); ;//new Color(0.1f, 0.3f, 0.9f));
    }

    public static Color Get(ColorType type)
    {
        return _dictionary[type];
    }

    public static List<ColorType> GetList()
    {
        return new List<ColorType>(_dictionary.Keys);
    }
}