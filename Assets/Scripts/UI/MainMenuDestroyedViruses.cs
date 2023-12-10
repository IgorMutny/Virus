using UnityEngine;

public class MainMenuDestroyedViruses : MonoBehaviour
{
    private void Start()
    {
        TextBox localizator = GetComponent<TextBox>();
        localizator.Initialize();
        int count = PlayerStats.Instance.VirusesDestroyed;

        string text =
            TextDictionary.Get(TextEnum.YouHaveDestroyed) +
            "\n" +
            count.ToString() +
            TextDictionary.Get(TextEnum.Virus) +
            VirusSuffix.Get(count, PlayerStats.Instance.Language) +
            "!";

        localizator.SetText(text);
    }
}
