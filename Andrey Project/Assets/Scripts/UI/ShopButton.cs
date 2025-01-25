using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Button button;

    public void Init(int num)
    {
        buttonText.text = $"skin {num + 1}";
        button.onClick.AddListener(()=>
        {
            PlayerData.ChangeSkin(num);
        });
    }
}
