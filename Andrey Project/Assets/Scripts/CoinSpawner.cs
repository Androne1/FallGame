using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> places = new List<Transform>();
    [SerializeField] private Coin coin;
    [SerializeField] private float spawnRate;

    private Coin spawnedCoin;

    private void OnEnable()
    {
        var randomPlace = Random.Range(0, places.Count);
        var randomChance = Random.Range(0, 100);

        if (randomChance >= spawnRate)
        {
            if (spawnedCoin == null)
            {
                spawnedCoin = Instantiate(coin, places[randomPlace]);
            }
        }
    }
}
