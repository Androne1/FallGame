using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkinHolder : ScriptableObject
{
    [SerializeField] private List<GameObject> skins = new List<GameObject>();
    public List<GameObject> Skins => skins; 
}
