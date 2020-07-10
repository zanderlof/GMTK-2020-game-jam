using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject player;

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
                if (math.abs(player.transform.position.x - transform.position.x) < 1.0f && math.abs(player.transform.position.y - transform.position.y) < 1.0f)
                {
                    held = true;
                }
            }
            else
            {
                held = false;
            }
        }
        if(held)
        {
            transform.position = player.transform.position;
            transform.position += Vector3.back * 0.01f;
        }
    }
}
