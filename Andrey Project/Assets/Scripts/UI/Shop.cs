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
        backButton.onClick.AddListener(Close);

        for (int i = 0; i < skinHolder.Skins.Count; i++)
        {
            var shopButton = Instantiate(shopButtonPrefab, content);
            shopButton.Init(i);
        }
    }

    private void Close()
    {
        gameObject.SetActive(false);

        PlayerData.Save();
    }
}
