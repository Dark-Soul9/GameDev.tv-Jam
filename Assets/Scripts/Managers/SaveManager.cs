using UnityEngine;

public static class SaveManager
{
    // Call this when starting a **New Game**
    public static void StartNewGame()
    {
        PlayerPrefs.DeleteAll();      // Delete previous save completely
        PlayerPrefs.SetInt("SaveExists", 1);  // Mark new save started
        PlayerPrefs.Save();
    }

    // Save BOOL
    public static void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }


    // Load BOOL
    public static bool LoadBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }

    // Save INT
    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    // Load INT
    public static int LoadInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    // Check if there is a saved game
    public static bool SaveExists()
    {
        return PlayerPrefs.GetInt("SaveExists", 0) == 1;
    }
}
