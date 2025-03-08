using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class SingleSkinSO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private GameObject visual;
    [SerializeField] private float price;
    public string Name => name;
    public GameObject Visual => visual;
    public float Price => price;

    
}


