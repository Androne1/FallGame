using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

[System.Serializable]
public class SaveData
{
    public string currentSkins;
    public List<string> unlockedSkons;
    public int coins;
    public int highScore;
}

public static class PlayerData
{
    private static string filePath = Path.Combine(Application.persistentDataPath, "playerdata.json");
    private static string currentSkin;
    private static List<string> unlockedSkins;
    private static int coins;
    private static int highScore;

    public static string CurrentSkin => CurrentSkin;
    public static List<string> UnlockedSkins => unlockedSkins;
    public static int Coins => coins;
    public static int HighScore => highScore;

    public static void Save()
    {
        SaveData data = new SaveData();
        {
            currentSkin = currentSkin;
            unlockedSkins = unlockedSkins;
            coins = coins;
            highScore = highScore;
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public static void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentSkin = data.currentSkins;
            unlockedSkins = data.unlockedSkons ?? new List<string>();
            coins = data.coins;
            highScore = data.highScore;
        }
    }

    public static void ChangeSkin(string skinName)
    {
        currentSkin = skinName;
    }

    public static void AddSkin(string skinName)
    {
        if(!unlockedSkins.Contains(skinName))
        {
            unlockedSkins.Add(skinName);
        }
    }

    public static void AddCoins(int amount)
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
