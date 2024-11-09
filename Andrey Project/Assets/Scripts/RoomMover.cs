using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Vector3.up * speed;
        if (transform.position.y >= 16)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
