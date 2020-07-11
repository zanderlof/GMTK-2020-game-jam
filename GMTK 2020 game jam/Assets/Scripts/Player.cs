using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameObject tool;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * 0.02f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * 0.02f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.02f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.02f;
        }

        //move held tool with player
        if(tool != gameObject)
        {
            tool.transform.position = transform.position;
            tool.transform.position += Vector3.back * 0.01f;
        }
        
        
    }

    public void Holding(GameObject thing)
    {
        tool = thing;
    }
    public void DropHeld()
    {
        tool = gameObject;
    }
}
