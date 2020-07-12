using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D;

public class Door : MonoBehaviour
{
    public bool isOpened;
    public List<RoomManager> connectingRooms;

    public GameObject player;
    public float interactRadius;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (math.abs(player.transform.position.x - transform.position.x) < interactRadius && math.abs(player.transform.position.y - transform.position.y) < interactRadius)
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        if (isOpened)
        {
            isOpened = false;
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            isOpened = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
