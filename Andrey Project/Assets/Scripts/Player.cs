using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SkinHolder skinHolder;
    private Rigidbody body;
    private const int dangerLayer = 10;

    private void Awake()
    {
        int skinNum = skinHolder.FindNumByName(PlayerData.CurrentSkin);
        if (skinNum < 0)
        {
            skinNum = 0;
        }
        Instantiate(skinHolder.Skins[skinNum].Visual, transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontal, vertical, 0) * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == dangerLayer)
        {
            UI.Instance.ShowMenu(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            coin.SpawnCoin();
        }
    }
}
