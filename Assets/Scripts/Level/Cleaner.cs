using System.Collections.Generic;

public class Cleaner
{
    private readonly int _minimalLineLengthToDestroy = 4;

    private Container _container;
    private List<Cell> _selectedCells = new();
    private List<Cell> _currentCells = new();
    private ColorType _currentColor;

    public Cleaner(Container container)
    {
        _container = container;
    }

    public bool Execute()
    {
        CheckRows();
        CheckColumns();
        bool result = _selectedCells.Count > 0;
        RemoveSelectedCells();

        if (result == true)
        {
            EventBus.Invoke(new CellCleaned());
        }
        return result;
    }

    private void CheckRows()
    {
        for (int x = 0; x < Container.Width; x++)
        {
            for (int y = 0; y < Container.Height; y++)
            {
                CheckPosition(x, y);
            }

            _currentCells.Clear();
        }
    }

    private void CheckColumns()
    {
        for (int y = 0; y < Container.Height; y++)
        {
            for (int x = 0; x < Container.Width; x++)
            {
                CheckPosition(x, y);
            }

            _currentCells.Clear();
        }
    }

    private void CheckPosition(int x, int y)
    {
        Cell cell = _container.Get(x, y);

        if (cell != null)
        {
            CheckCell(cell);
        }
        else
        {
            _currentCells.Clear();
        }
    }

    private void CheckCell(Cell cell)
    {
        ColorType color = cell.Color;

        if (color == _currentColor)
        {
            _currentCells.Add(cell);
            CheckCurrentCells();
        }
        else
        {
            _currentCells.Clear();
            _currentCells.Add(cell);
            _currentColor = color;
        }
    }

    private void CheckCurrentCells()
    {
        if (_currentCells.Count >= _minimalLineLengthToDestroy)
        {
            foreach (Cell cell in _currentCells)
            {
                AddToSelectedCells(cell);
            }
        }
    }

    private void AddToSelectedCells(Cell cell)
    {
        if (_selectedCells.Contains(cell) == false)
        {
            _selectedCells.Add(cell);
        }
    }

    private void RemoveSelectedCells()
    {
        foreach (Cell cell in _selectedCells)
        {
            _container.Remove(cell);
        }

        _selectedCells.Clear();
    }
}
