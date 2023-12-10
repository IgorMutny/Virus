using System.Collections.Generic;
using UnityEngine;

public static class PillSpriteDictionary
{
    private static Dictionary<Vector2Int, Sprite> _dictionary = new();

    static PillSpriteDictionary()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Game/pills");
        
        _dictionary.Add(Vector2Int.up, sprites[0]);
        _dictionary.Add(Vector2Int.down, sprites[3]);
        _dictionary.Add(Vector2Int.left, sprites[1]);
        _dictionary.Add(Vector2Int.right, sprites[2]);
        _dictionary.Add(Vector2Int.zero, sprites[4]);
    }

    public static Sprite Get(Vector2Int direction)
    {
        return _dictionary[direction];
    }
}
