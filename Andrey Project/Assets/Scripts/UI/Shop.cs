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
            var shopButton = Instantiate(shopButtonPrefab, content);
            shopButton.Init(skinHolder.Skins[i]);
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
