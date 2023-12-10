using System.Collections.Generic;
using UnityEngine;

public class ColorTable
{
    private ColorType[,] _table;

    public ColorTable(int width, int height)
    {
        _table = new ColorType[width, height];

        Fill(width, height);
    }

    public ColorType Get(int x, int y)
    {
        return _table[x, y];
    }

    private void Fill(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                FillPosition(x, y);
            }
        }
    }

    private void FillPosition(int x, int y)
    {
        List<ColorType> availableColors = ColorDictionary.GetList();
        List<ColorType> nonAvailableColors = new();

        foreach (ColorType colorType in availableColors)
        {
            if (IsColorAllowed(colorType, x, y) == false)
            {
                nonAvailableColors.Add(colorType);
            }
        }

        availableColors.RemoveAll(nonAvailableColors.Contains);

        ColorType currentColor = availableColors[Random.Range(0, availableColors.Count)];
        _table[x, y] = currentColor;
    }

    private bool IsColorAllowed(ColorType color, int x, int y)
    {
        if (IsSameColor(x, y, -2, 0, color) == true)
        {
            return false;
        }

        if (IsSameColor(x, y, 0, -2, color) == true)
        {
            return false;
        }

        return true;
    }

    private bool IsSameColor(int x, int y, int offsetX, int offsetY, ColorType color)
    {
        if (x + offsetX < 0 || y + offsetY < 0)
        {
            return false;
        }
        else
        {
            return _table[x + offsetX, y + offsetY] == color;
        }
    }
}
