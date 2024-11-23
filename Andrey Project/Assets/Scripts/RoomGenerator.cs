using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] List <Rigidbody> roomRbs = new List<Rigidbody>();
    [SerializeField] List <Transform> roomPos= new List<Transform>();
    [SerializeField] Rigidbody firstRoom;
    [SerializeField] float speed;
    [SerializeField] Transform camera;
    private int roomsCount;
    private Action OnMoveEnd;
    // Start is called before the first frame update
    void Awake()
    {   
        OnMoveEnd = ()=> GenerateRoom(roomPos[roomPos.Count-1]);
        firstRoom.gameObject.SetActive(true);
        roomsCount = roomRbs.Count;

        StartCoroutine(MoveRoom(firstRoom));
        foreach (var room in roomPos)
        {
            GenerateRoom(room);
        }
    }

    private void GenerateRoom(Transform room)
    {
        int randomNumber = Random.Range(0, roomsCount);
        while (roomRbs[randomNumber].gameObject.activeSelf == true)
        {
            randomNumber = Random.Range(0, roomsCount);
        }
        roomRbs[randomNumber].transform.position = room.position;
        roomRbs[randomNumber].gameObject.SetActive(true);
        StartCoroutine(MoveRoom(roomRbs[randomNumber]));
    }

    private IEnumerator MoveRoom(Rigidbody body)
    {
        body.velocity = Vector3.up * speed;

        while (body.transform.position.y > camera.position.y)
        {
            yield return null;
        }

        body.velocity = Vector3.zero;
        body.gameObject.SetActive(false);

        OnMoveEnd?.Invoke();
    }
}
