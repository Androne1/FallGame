using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    private void Awake()
    {
        PlayerData.Load();
    }
}
