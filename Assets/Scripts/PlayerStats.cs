using YG;

public class PlayerStats
{
    public static PlayerStats Instance { get; private set; }

    public int MaxAllowedLevel { get; private set; }
    public int LastSelectedLevel { get; private set; }
    public Language Language { get; private set; }
    public float SoundVolume { get; private set; }
    public float MusicVolume { get; private set; }
    public int VirusesDestroyed { get; private set; }

    public PlayerStats()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("PlayerStats already exists");
        }

        LoadStats();
    }

    public void LoadStats()
    {
        MaxAllowedLevel = YandexGame.savesData.MaxAllowedLevel;
        LastSelectedLevel = YandexGame.savesData.LastSelectedLevel;
        Language = (Language)YandexGame.savesData.Language;
        SoundVolume = YandexGame.savesData.SoundVolume;
        MusicVolume = YandexGame.savesData.MusicVolume;
        VirusesDestroyed = YandexGame.savesData.VirusesDestroyed;
    }

    public void SaveStats()
    {
        YandexGame.savesData.MaxAllowedLevel = MaxAllowedLevel;
        YandexGame.savesData.LastSelectedLevel = LastSelectedLevel;
        YandexGame.savesData.Language = (int)Language;
        YandexGame.savesData.SoundVolume = SoundVolume;
        YandexGame.savesData.MusicVolume = MusicVolume;
        YandexGame.savesData.VirusesDestroyed = VirusesDestroyed;

        YandexGame.SaveProgress();
    }

    public void TrySetMaxAllowedLevel(int level)
    {
        if (level > MaxAllowedLevel)
        {
            MaxAllowedLevel = level;
            SaveStats();
        }
    }

    public void TrySetLastSelectedLevel(int level)
    {
        if (level <= MaxAllowedLevel)
        {
            LastSelectedLevel = level;
            SaveStats();
        }
    }

    public void SetLanguage(Language language)
    {
        Language = language;
        SaveStats();
    }

    public void SetSoundVolume(float volume)
    {
        SoundVolume = volume;
        SaveStats();
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        SaveStats();
    }

    public void AddDestroyedVirus()
    {
        VirusesDestroyed += 1;
        SaveStats();
    }
}
