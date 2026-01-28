using UnityEngine;

public static class FarmsApp
{
    public static int selectedTheme = 0;

    public static int score
    {
        get { return PlayerPrefs.GetInt("score", 0); }
        set { PlayerPrefs.SetInt("score", value); }
    }

    public static int music
    {
        get { return PlayerPrefs.GetInt("music", 1); }
        set { PlayerPrefs.SetInt("music", value); }
    }

    public static int sound
    {
        get { return PlayerPrefs.GetInt("ssound", 1); }
        set { PlayerPrefs.SetInt("ssound", value); }
    }

    public static int coins
    {
        get { return PlayerPrefs.GetInt("coins", 0); }
        set
        {
            PlayerPrefs.SetInt("coins", value);
        }
    }
}