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
            save.wormsKilled = 0;
            save.timeGame = 0;
            save.fluidsL = 0;
            save.carKm = 0;
            save.totalGameplay = 0;
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

    public static void SaveEndGame(int wormsKilled, float km, float fluidsL, float timeGame)
    {
        Save save = GetSave();
        save.totalGameplay++;
        save.wormsKilled = wormsKilled;
        save.timeGame += timeGame;
        save.fluidsL += fluidsL;
        save.carKm += km;
        SaveGame(save);
    }

    public static int GetIdLanguage()
    {
        Save save = GetSave();
        return save.IdLanguage;
    }
}
