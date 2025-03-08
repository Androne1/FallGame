using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkinHolder : ScriptableObject
{
    [SerializeField] private List<SingleSkinSO> skins = new List<SingleSkinSO>();
    public List<SingleSkinSO> Skins => skins;

    public int FindNumByName(string name)
    {
        foreach (var skin in Skins)
        {
            if (skin.Name == name)
            {
                return Skins.IndexOf(skin);
            }
        }
        return -1;
    }
}
