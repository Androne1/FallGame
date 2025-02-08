using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float spawnDistance;
    [SerializeField] GameObject model;
    Transform player;
    bool inTrap;
    const int dangerLayer = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        model.SetActive(false);
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckCollision()
    { 
        model.SetActive(!inTrap);
    }

    public void SpawnCoin()
    {
        model.SetActive(false);
        inTrap = false;
        transform.position = player.position + new Vector3(0, 0, spawnDistance);
        CheckCollision();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == dangerLayer)
        {
            inTrap = true;
        }
    }

    
}
