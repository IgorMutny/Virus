using UnityEngine;

public class Message : MonoBehaviour
{
    TextBox _textBox;

    public void Initialize(float sizeX, float sizeY, TextEnum text, bool okButton = false)
    {
        _textBox = GetComponent<TextBox>();
        SetSpriteRenderer(sizeX, sizeY);

        _textBox.Initialize(text, 9);

        if (okButton == true)
        {
            CreateOKButton(sizeY);
        }
    }

    public void Initialize(float sizeX, float sizeY, string text, bool okButton = false)
    {
        _textBox = GetComponent<TextBox>();
        SetSpriteRenderer(sizeX, sizeY);

        _textBox.Initialize(9);
        _textBox.SetText(text);

        if (okButton == true)
        {
            CreateOKButton(sizeY);
        }
    }

    public void SetText(string text)
    {
        _textBox.SetText(text);
    }

    public void Close()
    {
        Destroy(gameObject);
    }

    private void SetSpriteRenderer(float sizeX, float sizeY)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Clickable.StandartColor;
        spriteRenderer.size = new Vector2(sizeX, sizeY);
    }

    private void CreateOKButton(float sizeY)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y - sizeY + 1.25f, 0);
        Instantiate(ObjectDictionary.Get(typeof(OKButton)), position, Quaternion.identity, transform);
    }
}
