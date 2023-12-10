using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public abstract class Cell : MonoBehaviour
{
    protected SpriteRenderer _spriteRenderer;
    public ColorType Color { get; private set; }

    public virtual void Initialize(ColorType color)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = ColorDictionary.Get(color);

        Color = color;
    }
}
