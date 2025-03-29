using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class SingleSkinSO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private GameObject visual;
    [SerializeField] private int price;
    public string Name => name;
    public GameObject Visual => visual;
    public int Price => price;

    
}


