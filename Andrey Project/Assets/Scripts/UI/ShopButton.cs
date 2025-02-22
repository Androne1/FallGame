using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Button button;
    [SerializeField] private TextMeshPro CostText;
    [SerializeField] Transform visualPlace;

    public void Init(SingleSkinSO skin)
    {
        buttonText.text = skin.Name;
        Instantiate(skin.Visual, visualPlace);
    }
}
