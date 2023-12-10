using System;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectDictionary
{
    private static Dictionary<Type, GameObject> _dictionary = new();

    static ObjectDictionary()
    {
        _dictionary.Add(typeof(Virus), Resources.Load<GameObject>("Prefabs/Game/Virus"));
        _dictionary.Add(typeof(Pill), Resources.Load<GameObject>("Prefabs/Game/Pill"));
        _dictionary.Add(typeof(Explosion), Resources.Load<GameObject>("Prefabs/Game/Explosion"));
        _dictionary.Add(typeof(Smoke), Resources.Load<GameObject>("Prefabs/Game/Smoke"));
        _dictionary.Add(typeof(Timer), Resources.Load<GameObject>("Prefabs/Game/Timer"));
        _dictionary.Add(typeof(Crack), Resources.Load<GameObject>("Prefabs/Game/Crack"));
        _dictionary.Add(typeof(SparkSpawner), Resources.Load<GameObject>("Prefabs/Game/SparkSpawner"));
        _dictionary.Add(typeof(Container), Resources.Load<GameObject>("Prefabs/Game/Container"));
        _dictionary.Add(typeof(MainMenu), Resources.Load<GameObject>("Prefabs/UI/MainMenu"));
        _dictionary.Add(typeof(LevelSelectionMenu), Resources.Load<GameObject>("Prefabs/UI/LevelSelectionMenu"));
        _dictionary.Add(typeof(LevelSelectionButton), Resources.Load<GameObject>("Prefabs/UI/LevelSelectionButton"));
        _dictionary.Add(typeof(SpeedSelectionButton), Resources.Load<GameObject>("Prefabs/UI/SpeedSelectionButton"));
        _dictionary.Add(typeof(GamePlayMenu), Resources.Load<GameObject>("Prefabs/UI/GamePlayMenu"));
        _dictionary.Add(typeof(GamePlayUI), Resources.Load<GameObject>("Prefabs/UI/GamePlayUI"));
        _dictionary.Add(typeof(Message), Resources.Load<GameObject>("Prefabs/UI/Message"));
        _dictionary.Add(typeof(OKButton), Resources.Load<GameObject>("Prefabs/UI/OKButton"));
        _dictionary.Add(typeof(WinMenu), Resources.Load<GameObject>("Prefabs/UI/WinMenu"));
        _dictionary.Add(typeof(LoseMenu), Resources.Load<GameObject>("Prefabs/UI/LoseMenu"));
    }

    public static GameObject Get(Type type)
    {
        return _dictionary[type];
    }
}
