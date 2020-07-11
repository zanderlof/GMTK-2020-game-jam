using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject tool;
    public GameObject player;
    public Player player2;
    public SpriteRenderer sprite;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        //timer = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= 0.01f;
            
        }
        else if (timer <= 0)
        {
            sprite.color = Color.red;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            if (math.abs(player.transform.position.x - transform.position.x) < 0.2f && math.abs(player.transform.position.y - transform.position.y) < 0.2f && player2.tool == tool)
            {
                timer = 15.0f;
                sprite.color = Color.green;
            }
        }
        
    }
}
