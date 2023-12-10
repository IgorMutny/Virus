using System.Collections.Generic;
using UnityEngine;

public class VirusCreator
{
    private Container _container;
    private ColorTable _colorTable;
    private List<PositionBag> _positionBags = new();
    private int _positionBagIndex;
    private int _infectedHeight;
    private int _virusesCount;

    public VirusCreator(Container container, int level)
    {
        _container = container;

        _infectedHeight = LevelCalculator.InfectedHeight(level);
        _virusesCount = LevelCalculator.VirusesCount(level);
    }

    public List<Virus> Execute()
    {
        _colorTable = new ColorTable(Container.Width, _infectedHeight);

        for (int i = 0; i < ColorDictionary.GetList().Count; i++)
        {
            PositionBag positionBag = new PositionBag(_colorTable, _infectedHeight, (ColorType)i);
            _positionBags.Add(positionBag);
        }

        _positionBagIndex = Random.Range(0, _positionBags.Count);

        List<Virus> results = new List<Virus>();

        for (int i = 0; i < _virusesCount; i++)
        {
            Virus virus = CreateVirus();
            results.Add(virus);
        }

        return results;
    }

    private Virus CreateVirus()
    {
        Vector2Int position = _positionBags[GetNextPositionBagIndex()].GetRandom();
        ColorType color = _colorTable.Get(position.x, position.y);

        Virus virus = (Virus)CellFactory.Create(typeof(Virus), position, color);
        _container.Set(virus, position.x, position.y);

        return virus;
    }

    private int GetNextPositionBagIndex()
    {
        for (int i = 0; i < _positionBags.Count; i++)
        {
            _positionBagIndex += 1;

            if (_positionBagIndex >= _positionBags.Count)
            {
                _positionBagIndex = 0;
            }

            if (_positionBags[_positionBagIndex].IsEmpty() == false)
            {
                return _positionBagIndex;
            }
        }

        throw new System.Exception($"{this}: all position bags are empty");
    }
}


//    private Virus AddVirus()
//    {
//        List<Vector2Int> currentPositionBag = GetNextPositionBag();
//        Vector2Int position = currentPositionBag[Random.Range(0, currentPositionBag.Count)];
//        currentPositionBag.Remove(position);

//        ColorType color = _colorTable.Get(position);

//        return (Virus)_container.CreateCell(typeof(Virus), position, color);
//    }

