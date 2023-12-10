public static class VirusSuffix
{
    public static string Get(int count, Language language)
    { 
        string result = "";

        if (language == Language.English)
        {
            result = GetEnglish(count);
        }

        if (language == Language.Russian)
        {
            result = GetRussian(count);
        }

        return result;
    }

    private static string GetEnglish(int count)
    { 
        if (count == 1)
        {
            return "";
        }
        else
        {
            return "ES";
        }
    }

    private static string GetRussian(int count)
    {
        if (count % 100 > 10 && count % 100 < 20)
        {
            return "ÎÂ";
        }
        else if (count % 10 == 1)
        {
            return "";
        }
        else if (count % 10 >= 2 && count % 10 <= 4)
        {
            return "À";
        }
        else
        {
            return "ÎÂ";
        }
    }
}
