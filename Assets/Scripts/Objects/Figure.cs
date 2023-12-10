using UnityEngine;

public class Figure
{
    private Pill[] _pills = new Pill[2];

    public Figure(Vector2Int[] positions, ColorType[] colors)
    {
        for (int i = 0; i < 2; i++)
        {
            _pills[i] = (Pill)CellFactory.Create(typeof(Pill), positions[i], colors[i]);
        }

        for (int i = 0; i < 2; i++)
        {
            int j = GetSecondNumber(i);
            _pills[i].Pair = _pills[j];
        }
    }

    public Vector2Int[] GetPositions()
    {
        Vector2Int[] results = new Vector2Int[2];

        for (int i = 0; i < 2; i++)
        {
            results[i] = Vector2Int.RoundToInt(_pills[i].transform.position);
        }

        return results;
    }

    public void Move(Vector2Int[] positions)
    {
        if (PositionsAreValid(positions) == false)
        {
            throw new System.Exception($"{this}: positions {positions[0]}, {positions[1]} are not valid");
        }

        for (int i = 0; i < 2; i++)
        {
            _pills[i].transform.position = (Vector2)positions[i];
        }

        for (int i = 0; i < 2; i++)
        {
            _pills[i].UpdateDirection();
        }
    }

    public void SendToContainer(Container container)
    {
        for (int i = 0; i < 2; i++)
        {
            int x = (int)Mathf.Round(_pills[i].transform.position.x);
            int y = (int)Mathf.Round(_pills[i].transform.position.y);

            container.Set(_pills[i], x, y);
            _pills[i] = null;
        }
    }

    public void Erase()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject.Destroy(_pills[i].gameObject);
            _pills[i] = null;
        }
    }

    private bool PositionsAreValid(Vector2Int[] positions)
    {
        int deltaX = Mathf.Abs(positions[0].x - positions[1].x);
        int deltaY = Mathf.Abs(positions[0].y - positions[1].y);

        return (deltaX == 1 && deltaY == 0) || (deltaX == 0 && deltaY == 1);
    }

    public static int GetSecondNumber(int i)
    {
        return i == 0 ? 1 : 0;
    }
}
