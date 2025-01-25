using UnityEngine;

public static class PlayerData
{
    private static int skinNum;
    public static int SkinNum => skinNum;

    public static void Save()
    {
        PlayerPrefs.SetInt("skinNum", skinNum);
    }

    public static void Load()
    {
        skinNum = PlayerPrefs.GetInt("skinNum");
    }

    public static void ChangeSkin(int num)
    {
        skinNum = num;
    }
}
