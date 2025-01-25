using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] List<Transform> roomsRbs = new List<Transform>();
    [SerializeField] List<Transform> roomsPos = new List<Transform>();
    [SerializeField] Transform firstRoom;
    [SerializeField] float speed;
    private int roomsCount;
    private Action<Transform> OnMoveEnded;

    // Start is called before the first frame update
    void Awake()
    {
        OnMoveEnded = (pos) => GenerateRoom(pos);
        firstRoom.gameObject.SetActive(true);
        roomsCount = roomsRbs.Count;

        StartCoroutine(MoveRoom(firstRoom));
        foreach (var room in roomsPos) 
        {
            GenerateRoom(room);
        }
    }

    private void GenerateRoom(Transform room)
    {
        int randomNum = Random.Range(0, roomsCount);
        while (roomsRbs[randomNum].gameObject.activeSelf == true)
        {
            randomNum = Random.Range(0, roomsCount);
        }
        roomsRbs[randomNum].transform.position = room.position;
        roomsRbs[randomNum].gameObject.SetActive(true);

        StartCoroutine(MoveRoom(roomsRbs[randomNum]));
    }

    private IEnumerator MoveRoom(Transform body)
    {
        while (body.transform.position.z > -7)
        {
            body.position += Vector3.back * speed * Time.deltaTime;
            yield return null;
        }

        body.gameObject.SetActive(false);

        OnMoveEnded(roomsPos[roomsPos.Count-1]);
    }
}
