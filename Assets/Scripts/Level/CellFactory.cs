using UnityEngine;

public static class CellFactory
{
    public static Cell Create(System.Type type, Vector2Int position, ColorType color)
    {
        Cell cell = GameObject.Instantiate(ObjectDictionary.Get(type), (Vector2)position, Quaternion.identity)
                .GetComponent<Cell>();
        cell.Initialize(color);

        return cell;
    }
}
