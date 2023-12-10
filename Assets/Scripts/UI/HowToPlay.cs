using System.Collections.Generic;
using UnityEngine;

public class HowToPlay
{
    private Message _message;
    private int _currentMessageID = 0;

    private List<Vector2> _messageSizes = new()
    {
        new Vector2(7.2f, 5),
        new Vector2(7.2f, 5.5f),
        new Vector2(7.2f, 9f),
        new Vector2(7.2f, 6),
        new Vector2(7.2f, 6.5f)
    };

    private List<TextEnum> _texts = new()
    {
        TextEnum.HowToPlay1,
        TextEnum.HowToPlay2,
        TextEnum.HowToPlay3,
        TextEnum.HowToPlay4,
        TextEnum.HowToPlay5
    };

    public HowToPlay()
    {
        CreateMessage(0);
    }

    public void TryShowNextMessage()
    {
        _currentMessageID += 1;

        if (_currentMessageID < _texts.Count)
        {
            CreateMessage(_currentMessageID);
        }
        else
        {
            FinishHowToPlay();
        }
    }

    public void FinishHowToPlay()
    {
        EventBus.Invoke(new HowToPlayFinished());
    }

    private void CreateMessage(int id)
    {
        _message = GameObject.Instantiate(ObjectDictionary.Get(typeof(Message))).GetComponent<Message>();
        _message.Initialize(_messageSizes[id].x, _messageSizes[id].y, _texts[id], true);
        _message.gameObject.AddComponent<HowToPlayMessage>().SetParent(this);
    }
}
