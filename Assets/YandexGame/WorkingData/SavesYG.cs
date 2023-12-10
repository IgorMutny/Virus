
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int MaxAllowedLevel;
        public int LastSelectedLevel;
        public int Language;
        public float SoundVolume;
        public float MusicVolume;
        public int VirusesDestroyed;

        public SavesYG()
        {
            MaxAllowedLevel = 0;
            LastSelectedLevel = 0;
            Language = 1;
            SoundVolume = 1f;
            MusicVolume = 0.25f;
            VirusesDestroyed = 0;
        }
    }
}
