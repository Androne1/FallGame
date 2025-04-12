using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Button button;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] Transform visualPlace;

    private bool unlocked;

    public void Init(SingleSkinSO skin, Action<SingleSkinSO, Action, bool> buyAction, bool isUnlocked)
    {
        unlocked = isUnlocked;

        if (isUnlocked)
        {
            costText.text = "unlocked";
        } else
        {
            costText.text = skin.Price.ToString();
        }

        buttonText.text = skin.Name;      
        Instantiate(skin.Visual, visualPlace);
        button.onClick.AddListener(() => buyAction?.Invoke(skin, Unlock, unlocked));
    }

    public void Unlock()
    {
        unlocked = true;
        costText.text = "unlocked";
    }
}
