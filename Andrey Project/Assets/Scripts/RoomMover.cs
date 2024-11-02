using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMover : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Vector3.forward;
    }
}
