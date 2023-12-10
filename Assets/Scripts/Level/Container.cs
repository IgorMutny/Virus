using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public static readonly int Width = 8;
    public static readonly int Height = 16;

    public static readonly Vector2Int[] StartPositions = new Vector2Int[2]
    {
            new Vector2Int(Width / 2 - 1, Height - 1),
            new Vector2Int(Width / 2, Height - 1)
    };

    private int _level;
    private List<Virus> _viruses;
    private Cell[,] _cells = new Cell[Width, Height];

    public void Initialize(int level)
    {
        _level = level;

        VirusCreator virusCreator = new VirusCreator(this, _level);
        _viruses = virusCreator.Execute();
        EventBus.Invoke(new VirusesCountChanged(_viruses.Count, LevelCalculator.VirusesCount(_level)));
    }

    public Cell Get(int x, int y)
    {
        return _cells[x, y];
    }

    public void Set(Cell cell, int x, int y)
    {
        if (_cells[x, y] != null)
        {
            throw new System.Exception($"{this}: can not set cell {cell} in position ({x}, {y}): position is not empty");
        }

        _cells[x, y] = cell;
    }

    public Vector2Int Find(Cell cell)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (cell == _cells[x, y])
                {
                    return new Vector2Int(x, y);
                }
            }
        }

        throw new System.Exception($"{this}: cell {cell} does not exist");
    }

    public void Move(Cell cell, int x, int y)
    {
        if (_cells[x, y] != null)
        {
            throw new System.Exception($"{this}: can not move cell {cell} to position ({x}, {y}): position is not empty");
        }

        if (cell is not Pill)
        {
            throw new System.Exception($"{this}: can not move cell {cell}: cell is not a pill");
        }

        Vector2Int position = Find(cell);
        _cells[position.x, position.y] = null;
        _cells[x, y] = cell;
        cell.transform.position = new Vector2(x, y);
    }

    public void Remove(Cell cell)
    {
        Vector2Int position = Find(cell);
        ColorType color = cell.Color;

        if (_cells[position.x, position.y] is Virus)
        {
            DestroyVirus((Virus)_cells[position.x, position.y]);
        }

        _cells[position.x, position.y] = null;
        GameObject.Destroy(cell.gameObject);

        CreateExplosion(position, color);
    }

    public bool StartPositionsAreEmpty()
    {
        for (int i = 0; i < 2; i++)
        {
            if (_cells[StartPositions[i].x, StartPositions[i].y] != null)
            {
                return false;
            }
        }

        return true;
    }

    public void Erase()
    {
        foreach (Cell cell in _cells)
        {
            if (cell != null)
            {
                GameObject.Destroy(cell.gameObject);
            }
        }

        GameObject.Destroy(gameObject);
    }

    public bool PositionIsValid(Vector2Int position)
    {
        bool xIsValid = position.x >= 0 && position.x < Width;
        bool yIsValid = position.y >= 0 && position.y < Height;
        return xIsValid && yIsValid;
    }

    private void CreateExplosion(Vector2Int position, ColorType color)
    {
        GameObject explosionSample = ObjectDictionary.Get(typeof(Explosion));
        Explosion explosion =
                GameObject.Instantiate(explosionSample, (Vector2)position, Quaternion.identity).GetComponent<Explosion>();
        explosion.Initialize(color, LevelCalculator.TimeStep(_level));
    }

    private void DestroyVirus(Virus virus)
    {
        _viruses.Remove(virus);

        EventBus.Invoke(new VirusesCountChanged(_viruses.Count, LevelCalculator.VirusesCount(_level)));
        PlayerStats.Instance.AddDestroyedVirus();

        if (_viruses.Count == 0)
        {
            EventBus.Invoke(new GameOver(GameOverType.Victory));
        }
    }
}
