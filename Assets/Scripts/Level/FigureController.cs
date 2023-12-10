using UnityEngine;

public class FigureController
{
    private Container _container;
    private Figure _figure;

    public FigureController(Container container)
    {
        _container = container;
    }

    public void SetFigure(Figure figure)
    {
        _figure = figure;
    }

    public void OnTimeStep()
    {
        TryExecute(ActionType.Drop);
    }

    public void TryExecute(ActionType action)
    {
        Vector2Int[] positions = _figure.GetPositions();
        Vector2Int[] newPositions = FigurePositionCalculator.GetNewPositions(positions, action);

        if (NewPositionsAreEmpty(newPositions) == true)
        {
            Execute(newPositions);
        }
        else if (action == ActionType.Drop)
        {
            SendToContainer();
        }
    }

    public void HandleKey(ActionType key)
    {
        TryExecute(key);
    }

    public void Erase()
    {
        if (_figure != null)
        { 
            _figure.Erase();
        }

        _figure = null;
    }

    private bool NewPositionsAreEmpty(Vector2Int[] newPositions)
    {
        for (int i = 0; i < 2; i++)
        {
            if (_container.PositionIsValid(newPositions[i]) == false)
            {
                return false;
            };

            Cell cell = _container.Get(newPositions[i].x, newPositions[i].y);
            if (cell != null)
            {
                return false;
            }
        }

        return true;
    }

    private void Execute(Vector2Int[] newPositions)
    {
        _figure.Move(newPositions);
    }
 
    private void SendToContainer()
    {
        _figure.SendToContainer(_container);
        _figure = null;
        EventBus.Invoke(new FigureInstalled());
    }
}