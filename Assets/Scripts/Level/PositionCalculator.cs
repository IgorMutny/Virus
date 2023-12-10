using UnityEngine;

public static class FigurePositionCalculator
{
    public static Vector2Int[] GetNewPositions(Vector2Int[] positions, ActionType action)
    {
        Vector2Int[] newPositions = new Vector2Int[2];

        if (action == ActionType.Drop)
        {
            newPositions[0] = new Vector2Int(positions[0].x, positions[0].y - 1);
            newPositions[1] = new Vector2Int(positions[1].x, positions[1].y - 1);
        }

        if (action == ActionType.MoveLeft)
        {
            newPositions[0] = new Vector2Int(positions[0].x - 1, positions[0].y);
            newPositions[1] = new Vector2Int(positions[1].x - 1, positions[1].y);
        }

        if (action == ActionType.MoveRight)
        {
            newPositions[0] = new Vector2Int(positions[0].x + 1, positions[0].y);
            newPositions[1] = new Vector2Int(positions[1].x + 1, positions[1].y);
        }

        if (action == ActionType.TurnLeft)
        {
            newPositions = GetNewPositionsForTurn(positions, -1);
        }

        if (action == ActionType.TurnRight)
        {
            newPositions = GetNewPositionsForTurn(positions, 1);
        }

        return newPositions;
    }

    private static Vector2Int[] GetNewPositionsForTurn(Vector2Int[] positions, int direction)
    {
        Vector2Int[] result = new Vector2Int[2];

        int centralPill = GetCentralPill(positions, direction);
        int sidePill = Figure.GetSecondNumber(centralPill);

        int deltaX = positions[sidePill].x - positions[centralPill].x;
        int deltaY = positions[sidePill].y - positions[centralPill].y;

        int newSidePillX = positions[centralPill].x + deltaY * direction;
        int newSidePillY = positions[centralPill].y - deltaX * direction;

        result[centralPill] = positions[centralPill];
        result[sidePill] = new Vector2Int(newSidePillX, newSidePillY);

        if (result[0].x == result[1].x)
        {
            result[0].x -= direction;
            result[1].x -= direction;
        }

        return result;
    }

    private static int GetCentralPill(Vector2Int[] positions, int direction)
    {
        if (positions[0].y == positions[1].y)
        {
            return positions[0].x - positions[1].x == direction ? 0 : 1;
        }
        else
        {
            return positions[0].y < positions[1].y ? 0 : 1;
        }
    }

}
