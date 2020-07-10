using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // list of tools able to be used
    public enum Tools
    {
        Wrench,
        Crowbar,
        Hammer,
        FlameThrower,
        FireExtinguisher,
        ToolCount
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        
    }
}
