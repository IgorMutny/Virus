using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public abstract class Clickable : MonoBehaviour
{
    public static readonly Color StandartColor = new Color(0.25f, 0.82f, 1.00f);
    public static readonly Color ActiveColor = new Color(0.9f, 0.1f, 0.1f);
    public static readonly Color UnavailableColor = Color.gray;

    [SerializeField] protected TextBox Description;
    [SerializeField] private TextEnum Text;

    private Camera _camera;
    private BoxCollider2D _collider;

    protected SpriteRenderer SpriteRenderer;
    protected bool IsActivated = false;
    protected bool IsActivatedOnce = false;
    protected bool IsJustDeactivated = false;

    public virtual void Initialize()
    {
        _camera = Camera.main;
        _collider = GetComponent<BoxCollider2D>();

        if (Description != null)
        {
            if (Text != TextEnum.None)
            {
                Description.Initialize(Text);
            }
            else
            {
                Description.Initialize();
            }
        }

        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.color = StandartColor;
    }

    protected virtual void Update()
    {
        IsJustDeactivated = false;
        bool previousState = IsActivated;

        IsActivated = IsClicked() == true || IsTouched() == true;
        IsActivatedOnce = IsClickedOnce() == true; //add TouchedOnce

        if (previousState != IsActivated)
        {
            IsJustDeactivated = true;
        }

        if (IsActivatedOnce == true)
        {
            EventBus.Invoke(new ButtonPressed());
        }
    }

    private bool IsClicked()
    {
        if (Input.GetMouseButton(0) == true)
        {
            return IsUnderMouse();
        }
        else
        {
            return false;
        }
    }

    private bool IsClickedOnce()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            return IsUnderMouse();
        }
        else
        {
            return false;
        }
    }

    private bool IsUnderMouse()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, 0.1f, Vector2.zero);
        return hit.collider == _collider;
    }

    private bool IsTouched()
    {
        Touch[] touches = Input.touches;

        foreach (Touch touch in touches)
        {
            Vector3 touchPosition = _camera.ScreenToWorldPoint(touch.position);
            Vector2 origin = new Vector2(touchPosition.x, touchPosition.y);

            RaycastHit2D[] results = Physics2D.CircleCastAll(origin, 1f, Vector2.zero);
            foreach (RaycastHit2D result in results)
            {
                if (result.collider == _collider)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
