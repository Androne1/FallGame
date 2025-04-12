using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] float roomSize;
    [SerializeField] List<Transform> roomsRbs = new List<Transform>();
    [SerializeField] List<Transform> roomsPos = new List<Transform>();
    [SerializeField] Transform firstRoom;
    [SerializeField] float speed;
    private Transform lastAddedRoom;
    private Action<Transform> OnMoveEnded;

    void Awake()
    {
        OnMoveEnded = (pos) => GenerateRoom(pos, roomSize);
        firstRoom.gameObject.SetActive(true);

        StartCoroutine(MoveRoom(firstRoom, true));
        foreach (var room in roomsPos) 
        {
            GenerateRoom(room);
        }
    }

    private void GenerateRoom(Transform room, float delta = 0)
    {
        int randomNum = Random.Range(0, roomsRbs.Count);

        var newRoom = roomsRbs[randomNum];
        newRoom.transform.position = room.position + new Vector3(0, 0, delta);
        newRoom.gameObject.SetActive(true);
        lastAddedRoom = newRoom;
        roomsRbs.Remove(newRoom);

        StartCoroutine(MoveRoom(newRoom));
    }

    private IEnumerator MoveRoom(Transform body, bool isFirst = false)
    {
        while (body.transform.position.z > -7)
        {
            body.position += Vector3.back * speed * Time.deltaTime;
            yield return null;
        }

        body.gameObject.SetActive(false);
        if (!isFirst)
        {
            roomsRbs.Add(body);
        }

        OnMoveEnded(lastAddedRoom);
    }
}
