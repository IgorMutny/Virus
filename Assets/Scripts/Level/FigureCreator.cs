using UnityEngine;

public class FigureCreator
{
    public static readonly Vector2Int[] StartPositions = new Vector2Int[2]
    {
            new Vector2Int(10, 14),
            new Vector2Int(11, 14)
    };

    private Container _container;
    private ColorBag _colorBag;
    private Figure _figure;

    public FigureCreator(Container container)
    {
        _container = container;
        _colorBag = new ColorBag();
    }

    public void Create()
    {
        ColorType[] colors = new ColorType[2];

        for (int i = 0; i < 2; i++)
        {
            colors[i] = _colorBag.GetRandom();
        }

        _figure = new Figure(StartPositions, colors);
    }

    public void OnTimeStep()
    {
        if (_container.StartPositionsAreEmpty() == false)
        {
            EventBus.Invoke(new GameOver(GameOverType.Defeat));
        }
        else
        {
            _figure.Move(Container.StartPositions);
            EventBus.Invoke(new FigurePrepared(_figure));
        }
    }

    public void Reload()
    {
        _figure = null;
        Create();
    }

    public void Erase()
    {
        if (_figure != null)
        {
            _figure.Erase();
        }

        _figure = null;
    }
}
