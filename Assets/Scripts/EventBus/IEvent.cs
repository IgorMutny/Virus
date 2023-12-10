public interface IEvent { }

public class TimeStep : IEvent { }

public class FigurePrepared : IEvent 
{
    public readonly Figure Figure;

    public FigurePrepared(Figure figure)
    {
        Figure = figure;
    }
}

public class FigureInstalled : IEvent { }

public class ContainerUpdated : IEvent { }

public class KeyPressed : IEvent
{
    public readonly ActionType Key;

    public KeyPressed(ActionType key)
    {
        Key = key;
    }
}

public class ActionCalled: IEvent
{
    public readonly ActionType Key;

    public ActionCalled(ActionType key)
    {
        Key = key;
    }
}

public class VirusesCountChanged : IEvent
{
    public readonly int VirusesRemained;
    public readonly int VirusesTotal;

    public VirusesCountChanged(int virusesRemained, int virusesTotal)
    {
        VirusesRemained = virusesRemained;
        VirusesTotal = virusesTotal;
    }
}

public class GameOver : IEvent
{
    public readonly GameOverType Type;

    public GameOver(GameOverType type)
    {
        Type = type;
    }
}

public class GamePlayPaused : IEvent 
{
    public readonly bool Value;

    public GamePlayPaused(bool value)
    {
        Value = value;
    }
}

public class GameStateChanged: IEvent
{
    public readonly IGameState State;
    
    public GameStateChanged(IGameState state)
    {
        State = state;
    }
}

public class CellCleaned : IEvent { }

public class CountDownTick : IEvent { }

public class ButtonPressed : IEvent { }

public class SoundVolumeChanged: IEvent
{
    public readonly float Volume;

    public SoundVolumeChanged(float volume)
    {
        Volume = volume;
    }
}

public class MusicVolumeChanged : IEvent
{
    public readonly float Volume;

    public MusicVolumeChanged(float volume)
    {
        Volume = volume;
    }
}

public class ContainerCracked : IEvent { }

public class ContainerCleaned : IEvent { }

public class HowToPlayFinished : IEvent { }

public class NextLevelDefined: IEvent
{
    public int Value;

    public NextLevelDefined(int value)
    {
        Value = value;
    }
}