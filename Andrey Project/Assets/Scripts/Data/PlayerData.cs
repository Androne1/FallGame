using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public string currentSkin;
    public List<string> unlockedSkins;
    public float coins;
    public int highScore;
}

public static class PlayerData
{
    private static string filePath = Path.Combine(Application.persistentDataPath, "playerdata.json");
    private static string currentSkin;
    private static List<string> unlockedSkins;
    private static float coins;
    private static int highScore;

    public static string CurrentSkin => currentSkin;
    public static List<string> UnlockedSkins => unlockedSkins;
    public static float Coins => coins;
    public static int HighScore => highScore;

    public static void Save()
    {
        SaveData data = new SaveData()
        {
            currentSkin = currentSkin,
            unlockedSkins = unlockedSkins,
            coins = coins,
            highScore = highScore,
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public static void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentSkin = data.currentSkin;
            unlockedSkins = data.unlockedSkins ?? new List<string>();
            coins = data.coins;
            highScore = data.highScore;
        }
    }

    public static void Reset()
    {
        currentSkin = string.Empty;
        unlockedSkins = new List<string>();
        coins = 0;
        highScore = 0;

        Save();
    }

    public static void ChangeSkin(string skinName)
    {
        currentSkin = skinName;
        AddSkin(skinName);
    }

    public static void AddSkin(string skinName)
    {
        if(!unlockedSkins.Contains(skinName))
        {
            unlockedSkins.Add(skinName);
        }
    }

    public static void AddCoins(float amount)
    {
        coins += amount;
    }

    public static void SetHighScore(int score)
    {
        if(score > highScore)
        {
            highScore = score;
        }
    }
}
