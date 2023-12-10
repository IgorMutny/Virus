using System.Collections.Generic;

public static class TextDictionary
{
    private static List<Dictionary<TextEnum, string>> _texts = new();

    static TextDictionary()
    {
        Dictionary<TextEnum, string> english = new()
        {
            { TextEnum.SelectLevel, "SELECT LEVEL" },
            { TextEnum.StartLevel, "START GAME" },
            { TextEnum.Resume, "RESUME" },
            { TextEnum.MainMenu, "MAIN MENU" },
            { TextEnum.Level, "LEVEL" },
            { TextEnum.NormalSpeed, "NORMAL" },
            { TextEnum.FastSpeed, "FAST" },
            { TextEnum.CrazySpeed, "CRAZY" },
            { TextEnum.Next, "NEXT" },
            { TextEnum.Viruses, "VIRUSES" },
            { TextEnum.YouHaveDestroyed, "YOU HAVE DESTROYED " },
            { TextEnum.Virus, " VIRUS" },
            { TextEnum.WinText, "YOU WIN!" },
            { TextEnum.LoseText, "YOU LOSE!" },
            { TextEnum.Speed, "SPEED" },
            { TextEnum.SoundVolume, "SOUND VOLUME" },
            { TextEnum.MusicVolume, "MUSIC VOLUME" },
            { TextEnum.OK, "OK" },
            { TextEnum.GameCompleted, "Congratulations!\r\nYou have completed the game!" },
            { TextEnum.Credits, "Created by Igor Mutny" },
            { TextEnum.Restart, "RESTART" },
            { TextEnum.NextLevel, "NEXT LEVEL" },

            { TextEnum.HowToPlay1, "This chemical beaker contains\r\ndangerous viruses.\r\nYou should destroy them all.\r\nThe viruses can be\r\n red, yellow or blue." },
            { TextEnum.HowToPlay2, "Pills fall into the beaker\r\nthrough the upper tube.\r\n Each pill consists of\r\ntwo halves\r\nof red, yellow\r\nor blue color." },
            { TextEnum.HowToPlay3, "You can control the pill,\r\n while the pill is falling.\r\n\r\nLeft and right arrows\r\nto move the pill.\r\n\r\nZ and X on keyboard\r\nto turn the pill.\r\n\r\nDown arrow\r\nto drop it down.\r\n\r\nEsc on keyboard\r\nto pause the game." },
            { TextEnum.HowToPlay4, "Make a horizontal\r\nor a vertical line,\r\nconsisting of FOUR\r\nhalves of pills\r\nor viruses\r\nof the same color,\r\nand they will disappear!" },
            { TextEnum.HowToPlay5, "Destroy all the viruses\r\nin the beaker\r\nto win.\r\n\r\nYou lose if the beaker\r\nhas overflowed.\r\n\r\nGood luck!" }
        };

        _texts.Add(english);

        Dictionary<TextEnum, string> russian = new()
        {
            { TextEnum.SelectLevel, "ВЫБРАТЬ УРОВЕНЬ" },
            { TextEnum.StartLevel, "НАЧАТЬ ИГРУ" },
            { TextEnum.Resume, "ПРОДОЛЖИТЬ" },
            { TextEnum.MainMenu, "ГЛАВНОЕ МЕНЮ" },
            { TextEnum.Level, "УРОВЕНЬ" },
            { TextEnum.NormalSpeed, "ОБЫЧНАЯ" },
            { TextEnum.FastSpeed, "БЫСТРАЯ" },
            { TextEnum.CrazySpeed, "БЕЗУМНАЯ" },
            { TextEnum.Next, "ДАЛЕЕ" },
            { TextEnum.Viruses, "ВИРУСЫ" },
            { TextEnum.YouHaveDestroyed, "УНИЧТОЖЕНО: " },
            { TextEnum.Virus, " ВИРУС" },
            { TextEnum.WinText, "ПОБЕДА!" },
            { TextEnum.LoseText, "ПРОВАЛ!" },
            { TextEnum.Speed, "СКОРОСТЬ" },
            { TextEnum.SoundVolume, "ГРОМКОСТЬ ЗВУКА" },
            { TextEnum.MusicVolume, "ГРОМКОСТЬ МУЗЫКИ" },
            { TextEnum.OK, "OK" },
            { TextEnum.GameCompleted, "ПОЗДРАВЛЯЮ!\r\nИГРА ЗАВЕРШЕНА!" },
            { TextEnum.Credits, "Автор игры: Igor Mutny" },
            { TextEnum.Restart, "НАЧАТЬ ЗАНОВО" },
            { TextEnum.NextLevel, "СЛЕДУЮЩИЙ УРОВЕНЬ" },

            { TextEnum.HowToPlay1, "В химическом стакане\r\nнаходятся опасные вирусы,\r\n которые нужно уничтожить.\r\nВирусы бывают трех цветов:\r\n красные, желтые и синие." },
            { TextEnum.HowToPlay2, "Через верхнюю трубку\r\nв стакан падают пилюли.\r\n Каждая пилюля состоит\r\nиз двух половинок\r\nкрасного, желтого\r\nили синего цветов." },
            { TextEnum.HowToPlay3, "Пока пилюля падает вниз,\r\n ты можешь управлять ей.\r\n\r\nСтрелки влево и вправо,\r\nчтобы двигать пилюлю.\r\n\r\nЯ и Ч на клавиатуре,\r\nчтобы повернуть пилюлю.\r\n\r\nСтрелка вниз,\r\nчтобы сбросить пилюлю вниз.\r\n\r\nEsc на клавиатуре,\r\nчтобы включить паузу." },
            { TextEnum.HowToPlay4, "Составь по горизонтали\r\nили по вертикали\r\nлинию из ЧЕТЫРЕХ\r\nполовинок пилюль\r\nили вирусов\r\nодного цвета, -\r\nи они исчезнут!" },
            { TextEnum.HowToPlay5, "Если ты уничтожишь\r\nвсе вирусы в стакане, -\r\nты победишь.\r\n\r\nЕсли стакан переполнится, -\r\nты проиграешь.\r\n\r\nУдачи!" }
        };

        _texts.Add(russian);
    }

    public static string Get(TextEnum buttonName)
    {
        int language = (int)PlayerStats.Instance.Language;
        var dictionary = _texts[language];
        string name = dictionary[buttonName];

        return name;
    }
}