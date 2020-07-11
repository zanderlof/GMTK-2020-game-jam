using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameObject tool;
    public Rigidbody2D body;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }

        Move();

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

    private void Move()
    {
        body.velocity = movement * 2.5f;
    }
}
