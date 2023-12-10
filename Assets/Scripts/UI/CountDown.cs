using UnityEngine;

public class CountDown
{
    private Message _message;
    private int _delayInSteps;
    private int _level;
    private Vector2 _messageSize = new Vector2(4, 2);

    public CountDown(int level, int delayInSteps)
    {
        _delayInSteps = delayInSteps;
        _level = level + 1;

        _message = GameObject.Instantiate(ObjectDictionary.Get(typeof(Message))).GetComponent<Message>();
        string text = GetText();
        _message.Initialize(_messageSize.x, _messageSize.y, text);
    }

    public void OnTimeStep()
    {
        _delayInSteps -= 1;
        EventBus.Invoke(new CountDownTick());

        if (_delayInSteps > 0)
        {
            string text = GetText();
            _message.SetText(text);
        }
        else
        {
            Destroy();
            EventBus.Invoke(new ContainerUpdated());
        }
    }

    public void Destroy()
    {
        GameObject.Destroy(_message.gameObject);
    }

    private string GetText()
    {
        string result = TextDictionary.Get(TextEnum.Level) + " " + _level
            + "\n"
            + _delayInSteps.ToString() + "...";
        return result;
    }
}
