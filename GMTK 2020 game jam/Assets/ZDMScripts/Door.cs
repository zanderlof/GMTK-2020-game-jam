using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Door : MonoBehaviour
{
    public bool isOpened;
    public List<RoomManager> connectingRooms;

    public void OpenDoor()
    {
        if (isOpened)
        {
            isOpened = false;
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<SpriteShapeRenderer>().enabled = true;
        }
        else
        {
            isOpened = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteShapeRenderer>().enabled = false;
        }
    }
}
