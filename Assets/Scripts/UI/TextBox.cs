using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private TextMeshPro _text;

    public void Initialize(int order = 10)
    {
        CreateTextObject(order);
    }

    public void Initialize(TextEnum name, int order = 10)
    {
        CreateTextObject(order);

        string text = TextDictionary.Get(name);
        SetText(text);
    }

    public void SetText(string value)
    {
        _text.text = value;
    }

    private void CreateTextObject(int order)
    {
        GameObject textObject = new("Text");
        textObject.transform.SetParent(transform, false);

        _text = textObject.AddComponent<TextMeshPro>();
        _text.alignment = TextAlignmentOptions.Center;
        _text.fontSize = 4;
        _text.sortingOrder = order;
    }
}
