using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] ShopButton shopButtonPrefab;
    [SerializeField] Transform content;
    [SerializeField] SkinHolder skinHolder;

    void Start()
    {
        transform.localScale = Vector3.zero;
        backButton.onClick.AddListener(Close);

        for (int i = 0; i < skinHolder.Skins.Count; i++)
        {
            bool unlocked = CheckUnlocked(skinHolder.Skins[i]);
            var shopButton = Instantiate(shopButtonPrefab, content);
            shopButton.Init(skinHolder.Skins[i], BuySkin, unlocked);
        }
    }

    private bool CheckUnlocked(SingleSkinSO skin)
    {
        return PlayerData.UnlockedSkins.Contains(skin.name);
    }

    public void BuySkin(SingleSkinSO skin, Action unlockedAction, bool unlocked)
    {
        if (unlocked)
        {
            PlayerData.ChangeSkin(skin.name);
        }
        else if (PlayerData.Coins >= skin.Price)
        {
            PlayerData.ChangeSkin(skin.name);
            PlayerData.AddCoins(-skin.Price);
            unlockedAction?.Invoke();
        }
    }

    public void Open()
    {
        transform.localScale = Vector3.one;
    }

    public void Close()
    {
        transform.localScale = Vector3.zero;

        PlayerData.Save();
    }
}
