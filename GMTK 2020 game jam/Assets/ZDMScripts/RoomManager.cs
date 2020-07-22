using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Tilemaps;

public enum RoomState
{
    Normal,
    Infected,
    Hostile,
    Burning,
    Destroyed,
}

public class RoomManager : MonoBehaviour
{
    public RoomState roomState;
    private RoomState previousState;
    public List<Door> connectingDoors;
    public TilemapRenderer infection;

    public float infectionTimeMin_Closed, infectionTimeMax_Closed;
    public float infectionTimeMin_Opened, infectionTimeMax_Opened;
    private float infectionTime_Closed, infectionTime_Opened;
    private float infectionTimer;

    public float fireTick = 10;
    private float fireTimer;
    private int fireCount;

    // Start is called before the first frame update
    void Start()
    {
        infectionTime_Opened = Random.Range(infectionTimeMin_Opened, infectionTimeMax_Opened);
        infectionTime_Closed = Random.Range(infectionTimeMin_Closed, infectionTimeMax_Closed);
        infectionTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(roomState == RoomState.Infected)
        {
            for(int i = 0; i < connectingDoors.Count; i++)
            {
                if (connectingDoors[i].isOpened && infectionTimer >= infectionTime_Opened)
                {
                    for(int e = 0; e < connectingDoors[i].connectingRooms.Count; e++)
                    {
                        if(connectingDoors[i].connectingRooms[e].roomState == RoomState.Normal)
                        {
                            connectingDoors[i].connectingRooms[e].Infected();
                            infectionTime_Opened = Random.Range(infectionTimeMin_Opened, infectionTimeMax_Opened);
                            infectionTimer = 0;
                            Debug.Log(i);
                            break;
                        }
                    }
                }
                else if(!connectingDoors[i].isOpened && infectionTimer >= infectionTime_Closed)
                {
                    for (int e = 0; e < connectingDoors[i].connectingRooms.Count; e++)
                    {
                        if (connectingDoors[i].connectingRooms[e].roomState != RoomState.Normal)
                        {
                            connectingDoors[i].connectingRooms[e].Infected();
                            infectionTime_Closed = Random.Range(infectionTimeMin_Closed, infectionTimeMax_Closed);
                            infectionTimer = 0;
                            Debug.Log(i);
                            break;
                        }
                    }
                }
                infectionTimer += Time.deltaTime;
            }
        }

        if(roomState == RoomState.Burning)
        {
            if (fireTimer >= fireTick)
            {
                fireCount += 1;
                fireTimer -= fireTick;
            }
            fireTimer += Time.deltaTime;
        }
    }

    public void Extinguish()
    {
        if(fireCount < 1)
        {
            roomState = previousState;
        }
        else if(fireCount == 1)
        {
            roomState = RoomState.Normal;
        }
        else if(fireCount > 1)
        {
            roomState = RoomState.Destroyed;
        }
    }

    public void Infected()
    {
        //this.GetComponent<SpriteShapeRenderer>().color = Color.red;
        infectionTime_Opened = Random.Range(infectionTimeMin_Opened, infectionTimeMax_Opened);
        infectionTime_Closed = Random.Range(infectionTimeMin_Closed, infectionTimeMax_Closed);
        roomState = RoomState.Infected;
        infection.enabled = true;
        
    }

    public void Ignited()
    {
        previousState = roomState;
        roomState = RoomState.Burning;
    }
}
