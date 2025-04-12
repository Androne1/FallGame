using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] ShopButton shopButtonPrefab;
    [SerializeField] Transform content;
    [SerializeField] SkinHolder skinHolder;
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] LayoutGroup layoutGroup;

    void Start()
    {
        layoutGroup.enabled = false;
        coins.text = PlayerData.Coins.ToString();
        transform.localScale = Vector3.zero;
        backButton.onClick.AddListener(Close);

        for (int i = 0; i < skinHolder.Skins.Count; i++)
        {
            bool unlocked = CheckUnlocked(skinHolder.Skins[i]);
            var shopButton = Instantiate(shopButtonPrefab, content);
            shopButton.Init(skinHolder.Skins[i], BuySkin, unlocked);
        }

        StartCoroutine(WaitMoneySetup());
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
       } else
       {
            if (PlayerData.Coins >= skin.Price)
            {
                PlayerData.ChangeSkin(skin.name);
                PlayerData.AddCoins(-skin.Price);
                coins.text = PlayerData.Coins.ToString();
                unlockedAction?.Invoke();
            }
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

    private IEnumerator WaitMoneySetup()
    {
        yield return new WaitForSeconds(0.1f);
        layoutGroup.enabled = true;
    }
}
