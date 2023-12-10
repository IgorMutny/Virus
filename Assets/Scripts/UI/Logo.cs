using UnityEngine;

public class Logo : MonoBehaviour
{
    [SerializeField] private Sprite _rus;
    [SerializeField] private Sprite _eng;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Language language = PlayerStats.Instance.Language;

        if (language == Language.English)
        {
            spriteRenderer.sprite = _eng;
        }

        if (language == Language.Russian)
        {
            spriteRenderer.sprite = _rus;
        }
    }
}
