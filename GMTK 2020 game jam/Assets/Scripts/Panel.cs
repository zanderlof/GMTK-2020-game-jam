using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject tool;
    public GameObject player;
    public Player player2;
    public SpriteRenderer sprite;
    public RoomManager room;

    public float interactRadius;

    //timer valiables
    private float timer;
    public float timerInitial;
    public float timerRepair;
    public float timerSpeed;

    //colors
    public Color working;
    public Color broken;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerInitial;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= timerSpeed;
            
        }
        else if (timer <= 0)
        {
            sprite.color = broken;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            if (math.abs(player.transform.position.x - transform.position.x) < interactRadius && math.abs(player.transform.position.y - transform.position.y) < interactRadius && player2.tool == tool)
            {
                timer = timerRepair;
                sprite.color = working;
                room.roomState = RoomState.Normal;
                room.infection.enabled = false;
            }
        }
        
    }
}
