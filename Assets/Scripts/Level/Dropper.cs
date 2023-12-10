using System.Collections.Generic;
using UnityEngine;

public class Dropper
{
    private Container _container;
    private List<Pill> _selectedPills = new();

    public Dropper(Container container)
    {
        _container = container;
    }

    public bool Execute()
    {
        CheckAllPositions();
        bool result = _selectedPills.Count > 0;
        DropSelectedPills();
        return result;
    }

    private void CheckAllPositions()
    {
        for (int x = 0; x < Container.Width; x++)
        {
            for (int y = 0; y < Container.Height; y++)
            {
                Cell cell = _container.Get(x, y);
                if (cell is Pill)
                {
                    CheckPill((Pill)cell);
                }
            }
        }
    }

    private void CheckPill(Pill pill)
    {
        Pill pair = pill.Pair;

        if (CanDrop(pill) == true)
        {
            if (pair == null)
            {
                AddToSelectedPills(pill);
            }

            if (pair != null && CanDrop(pair) == true)
            {
                AddToSelectedPills(pill);
                AddToSelectedPills(pair);
            }
        }
    }

    private bool CanDrop(Pill pill)
    {
        Vector2Int position = _container.Find(pill);
        Vector2Int newPosition = GetPositionBelow(position);

        if (_container.PositionIsValid(newPosition) == false)
        {
            return false;
        }

        Cell cellBelow = _container.Get(newPosition.x, newPosition.y);
        if (cellBelow == null)
        {
            return true;
        }
        else if (cellBelow is Pill)
        {
            if (_selectedPills.Contains((Pill)cellBelow))
            {
                return true;
            }
            else if (cellBelow == pill.Pair)
            {
                return true;
            }
        }

        return false;
    }

    private void AddToSelectedPills(Pill pill)
    {
        if (_selectedPills.Contains(pill) == false)
        {
            _selectedPills.Add(pill);
        }
    }

    private void DropSelectedPills()
    {
        foreach (Pill pill in _selectedPills)
        {
            DropPill(pill);
        }

        _selectedPills.Clear();
    }

    private void DropPill(Pill pill)
    {
        Vector2Int position = _container.Find(pill);
        Vector2Int newPosition = GetPositionBelow(position);
        _container.Move(pill, newPosition.x, newPosition.y);
    }

    private Vector2Int GetPositionBelow(Vector2Int position)
    {
        int x = position.x;
        int y = position.y;
        return new Vector2Int(x, y - 1);
    }
}
