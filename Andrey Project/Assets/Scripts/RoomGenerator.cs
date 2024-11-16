using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Recorder.OutputPath;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] List <Rigidbody> roomRbs = new List<Rigidbody>();
    [SerializeField] List <Transform> roomPos= new List<Transform>();
    [SerializeField] Rigidbody firstRoom;
    [SerializeField] float speed;
    private int roomsCount;
    // Start is called before the first frame update
    void Awake()
    {
        firstRoom.gameObject.SetActive(true);
        roomsCount = roomRbs.Count;

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
    }
}
