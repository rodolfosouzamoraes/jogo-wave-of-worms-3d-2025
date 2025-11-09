using UnityEngine;

public static class DBMng
{
    private const string LOCAL_SAVE = "save"; 

    public static Save GetSave()
    {
        Save save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString(LOCAL_SAVE));
        if(save == null)
        {
            save = new Save();
            save.IdLanguage = 0;
            SaveGame(save);
        }
        return save;
    }

    public static void SaveGame(Save save)
    {
        string jsonSave = JsonUtility.ToJson(save);
        PlayerPrefs.SetString(LOCAL_SAVE, jsonSave);
    }

    public static void SaveLanguage(int id)
    {
        Save save = GetSave();
        save.IdLanguage = id;
        SaveGame(save);
    }

    public static int GetIdLanguage()
    {
        Save save = GetSave();
        return save.IdLanguage;
    }
}
