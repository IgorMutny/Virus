using UnityEngine;

public static class ByteConverter
{
    public static byte[] GetBytesFromInt(int value)
    {
        byte[] result = new byte[4];

        for (int i = 0; i < 4; i++)
        {
            result[i] = (byte)(value / (int)Mathf.Pow(256, 3 - i));
        }

        return result;
    }

    public static int GetIntFromBytes(byte[] bytes)
    {
        int result = 0;

        for (int i = 0; i < 4; i++)
        {
            result += bytes[i] * (int)Mathf.Pow(256, 3 - i);
        }

        return result;
    }
}
