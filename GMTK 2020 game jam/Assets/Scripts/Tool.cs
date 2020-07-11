using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject player;
    public Player player2;
    

    private bool held;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        held = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!held)
            {
                if (math.abs(player.transform.position.x - transform.position.x) < 0.2f && math.abs(player.transform.position.y - transform.position.y) < 0.2f )
                {
                    held = true;
                    player2.Holding(gameObject);
                }
            }
            else
            {
                player2.DropHeld();
                held = false;
            }
        }
       
    }
}
