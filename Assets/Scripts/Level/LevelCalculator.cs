using UnityEngine;

public static class LevelCalculator
{
    public static float TimeStep(int level)
    {
        int difficulty = level / (Level.MaxLevelInOneSpeed + 1);
        float timeStep = 0.5f / Mathf.Pow(1.75f, difficulty);
        return timeStep;
    }

    public static int VirusesCount(int level)
    {
        int count = level % (Level.MaxLevelInOneSpeed + 1) * 4 + 4;
        return count;
    }

    public static int InfectedHeight(int level)
    {
        int infectedHeight = 8 + level % (Level.MaxLevelInOneSpeed + 1) / 4;
        return infectedHeight;
    }

    public static int Speed(int level)
    {
        int speed = level / (Level.MaxLevelInOneSpeed + 1);
        return speed;
    }
}
