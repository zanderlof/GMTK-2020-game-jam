using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.WSA;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public Player player2;

    public GameObject particleSystem;

    public float pickupRadius;
    private bool held;

    // Start is called before the first frame update
    void Start()
    {
        held = false;
    }

    // Update is called once per frame
    void Update()
    {
        //pick up or drop the item
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!held)
            {
                if (math.abs(player.transform.position.x - transform.position.x) < pickupRadius && math.abs(player.transform.position.y - transform.position.y) < pickupRadius)
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

        //Activate the wepon
        if (held && Input.GetKeyDown(KeyCode.Q))
        {
            particleSystem.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            particleSystem.SetActive(false);
        }
    }
}
