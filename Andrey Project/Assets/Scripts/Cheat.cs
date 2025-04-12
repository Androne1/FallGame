using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    [SerializeField] Button coinsButton;
    void Start()
    {
        coinsButton.onClick.AddListener(AddMoney);
    }

    private void AddMoney()
    {
        PlayerData.AddCoins(100000);
    }
}
